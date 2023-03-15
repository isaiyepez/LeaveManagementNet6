using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.BusinessLogic.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LeaveManagement.BusinessLogic.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly AutoMapper.IConfigurationProvider _configurationProvider;
		private readonly IEmailSender _emailSender;

		public LeaveRequestRepository(ApplicationDbContext dbContext, 
            IMapper mapper,
            UserManager<Employee> userManager,
            ILeaveAllocationRepository leaveAllocationRepository,
            IHttpContextAccessor httpContextAccessor,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
            _leaveAllocationRepository = leaveAllocationRepository;
            _httpContextAccessor = httpContextAccessor;
			_configurationProvider = configurationProvider;
			_emailSender = emailSender;
		}

		public async Task ChangeApprovalStatus(int leaveRequestId, bool IsApproved)
		{
            LeaveRequest? leaveRequest = await GetByIdAsync(leaveRequestId);

            if (leaveRequest == null) return;

            leaveRequest.IsApproved = IsApproved;

            if (IsApproved)
            {
                LeaveAllocation? leaveAllocation = await 
                    _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.EmployeeId,
                    leaveRequest.LeaveTypeId);

                if (leaveAllocation == null) return;

                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

                leaveAllocation.NumberOfDays -= daysRequested;

                await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
            }
            //Either if is approved or not, we need to update the IsApproved
            await UpdateAsync(leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.EmployeeId);

            string approvalStatus = IsApproved ? "Approved" : "Denied";

            await _emailSender.SendEmailAsync(user.Email, $"Leave Request {approvalStatus}", $"Your leave request from " +
				$"{leaveRequest.StartDate} to {leaveRequest.StartDate} has been {approvalStatus}");
		}

		public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM leaveRequestCreateVM)
        {
            var user = await _userManager.GetUserAsync(
                _httpContextAccessor?.HttpContext?.User);

            if (user == null) return false;
            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, leaveRequestCreateVM.LeaveTypeId);

            if (leaveAllocation == null) return false;

            int daysRequested = (int)(leaveRequestCreateVM.EndDate.Value - leaveRequestCreateVM.StartDate.Value).TotalDays;

            if (daysRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            LeaveRequest leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestCreateVM);
            leaveRequest.DateRequested= DateTime.Now;
            leaveRequest.EmployeeId = user.Id;

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, "Leave Request Submitted Successfully", $"Your leave request from " +
                $"{leaveRequest.StartDate} to { leaveRequest.StartDate} has been submitted for approval" );

            return true;
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _dbContext.LeaveRequests.Include(lr => lr.LeaveType)                                                    
                                                              .ToListAsync();

            var adminLeaveRequestViewVM = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count(),
                ApprovedRequests = leaveRequests.Count(lr => lr.IsApproved == true),
                PendingRequests = leaveRequests.Count(lr => lr.IsApproved == null),
                RejectedRequests = leaveRequests.Count(lr => lr.IsApproved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in adminLeaveRequestViewVM.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.EmployeeId));
            }

            return adminLeaveRequestViewVM;

		}

		public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await _dbContext.LeaveRequests.Where(lr => lr.EmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? leaveRequestId)
        {
            LeaveRequest? leaveRequest = await _dbContext.LeaveRequests
                .Include(lr => lr.LeaveType)
                .FirstOrDefaultAsync(lr => lr.Id == leaveRequestId);

            if (leaveRequest == null) return null;

            LeaveRequestVM leaveRequestVM = _mapper.Map<LeaveRequestVM>(leaveRequest);
            leaveRequestVM.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest?.EmployeeId));

            return leaveRequestVM;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(
            _httpContextAccessor?.HttpContext?.User);

            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);

            var employeeLeaveRequestVM = new EmployeeLeaveRequestViewVM(allocations, requests);

            return employeeLeaveRequestVM;
        }

        public async Task CancelRequest(int leaveRequestId)
        {
			LeaveRequest? leaveRequest = await GetByIdAsync(leaveRequestId);

			if (leaveRequest == null) return;

			leaveRequest.IsCanceled = true;
			
			await UpdateAsync(leaveRequest);

			var user = await _userManager.FindByIdAsync(leaveRequest.EmployeeId);			

			await _emailSender.SendEmailAsync(user.Email, $"Leave Request Cancelled", $"Your leave request from " +
				$"{leaveRequest.StartDate} to {leaveRequest.StartDate} has been Cancelled");
		}
    }
}
