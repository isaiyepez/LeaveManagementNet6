using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Common.Constants;
using LeaveManagement.BusinessLogic.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.BusinessLogic.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
		private readonly AutoMapper.IConfigurationProvider _configurationProvider;
		private readonly IEmailSender _emailSender;

		public LeaveAllocationRepository(
            ApplicationDbContext context, 
            UserManager<Employee> userManager, 
            ILeaveTypeRepository leaveTypeRepository, 
            IMapper mapper,
			AutoMapper.IConfigurationProvider configurationProvider,
			IEmailSender emailSender) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
			_configurationProvider = configurationProvider;
			_emailSender = emailSender;
		}

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationVM>(_configurationProvider)
                .ToListAsync();

            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.LeaveAllocations = allocations;

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            var allocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (allocation == null)
            {
                return null;
            }

            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

            var leaveAllocationEdit = _mapper.Map<LeaveAllocationEditVM>(allocation);
            leaveAllocationEdit.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(allocation.EmployeeId));

            return leaveAllocationEdit;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetByIdAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();
            var employeesWithNewAllocations = new List<Employee>();

            foreach (var employee in employees)
            {
                if (!await AllocationExists(employee.Id, leaveTypeId, period))
                {
                    allocations.Add(new LeaveAllocation
                    {
                        EmployeeId = employee.Id,
                        LeaveTypeId = leaveTypeId,
                        Period = period,
                        NumberOfDays = leaveType.DefaultDays
                    });

                    employeesWithNewAllocations.Add(employee);

				}
            }

            await AddRangeAsync(allocations);

            foreach (var employee in employeesWithNewAllocations)
            {				
				await _emailSender.SendEmailAsync(employee.Email, "Leave Allocation posted", $"Your " +
			   $"{leaveType.Name} has been posted for the period of {period}");
			}
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations
                .AnyAsync(q => q.EmployeeId == employeeId
                            && q.LeaveTypeId == leaveTypeId
                            && q.Period == period);
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM leaveAllocationEditVM)
        {
            var leaveAllocation = await GetByIdAsync(leaveAllocationEditVM.Id);

            if (leaveAllocation == null)
            {
                return false;
            }

            leaveAllocation.Period = leaveAllocationEditVM.Period;
            leaveAllocation.NumberOfDays = leaveAllocationEditVM.NumberOfDays;
            await UpdateAsync(leaveAllocation);
            
            return true;
        }

		public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeID)
		{
			return await _context.LeaveAllocations.FirstOrDefaultAsync(la => la.EmployeeId == employeeId 
                                                            && la.LeaveTypeId == leaveTypeID);
		}
	}
}
