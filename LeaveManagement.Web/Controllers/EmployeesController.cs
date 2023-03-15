using AutoMapper;
using LeaveManagement.Common.Constants;
using LeaveManagement.BusinessLogic.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public EmployeesController(UserManager<Employee> userManager, 
            IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
        }
        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var employeeListVMs = _mapper.Map<List<EmployeeListVM>>(employees);
            return View(employeeListVMs);
        }

        // GET: EmployeesController/Details/employeeId
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var employeeAllocations = await _leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(employeeAllocations);
        }


        // GET: EmployeesController/EditAllocation/5
        public async Task<IActionResult> EditAllocation(int id)
        {
            var leaveAllocationEditVM = await _leaveAllocationRepository.GetEmployeeAllocation(id);
            if (leaveAllocationEditVM == null)
            {
                return NotFound();
            }           

            return View(leaveAllocationEditVM);
        }

        // POST: EmployeesController/EditAllocation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM leaveAllocationEditVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _leaveAllocationRepository.UpdateEmployeeAllocation(leaveAllocationEditVM))
                    {
                        return RedirectToAction(nameof(ViewAllocations), new { id = leaveAllocationEditVM.EmployeeId });
                    }
                }
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
            }
            
            leaveAllocationEditVM.Employee = _mapper.Map<EmployeeListVM>(_userManager.FindByIdAsync(leaveAllocationEditVM.EmployeeId));
            leaveAllocationEditVM.LeaveType = _mapper.Map<LeaveTypeVM>(await _leaveTypeRepository.GetByIdAsync(leaveAllocationEditVM.LeaveTypeId));

            return View(leaveAllocationEditVM);
        }

    }
}
