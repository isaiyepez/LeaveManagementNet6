using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Constants;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveRequestsController(ILeaveRequestRepository leaveRequestRepository, 
            IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        // GET: LeaveRequests
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var leaveRequests = await _leaveRequestRepository.GetAdminLeaveRequestList();
            return View(leaveRequests);
        }

		[Authorize(Roles = Roles.User)]
		public async Task<IActionResult> MyLeave(int? id)
        {
            var leaveRequestViewVM = await _leaveRequestRepository.GetLeaveDetails();
            
            return View(leaveRequestViewVM);

        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            LeaveRequestVM? leaveRequestVM = await _leaveRequestRepository.GetLeaveRequestAsync(id);
            
            if (leaveRequestVM == null) return NotFound();

            return View(leaveRequestVM);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ApproveRequest(int id, bool IsApproved)
        {
            try
            {
                await _leaveRequestRepository.ChangeApprovalStatus(id, IsApproved);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

		// GET: LeaveRequests/Create
		[Authorize(Roles = Roles.User)]
		public async Task<IActionResult> Create()
        {
            var leaveRequestCreateVM = new LeaveRequestCreateVM
            {
                LeaveTypes = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name")
            };
            
            return View(leaveRequestCreateVM);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.User)]
		public async Task<IActionResult> Create(LeaveRequestCreateVM leaveRequestCreateVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isValidRequest = await _leaveRequestRepository.CreateLeaveRequest(leaveRequestCreateVM);
                    
                    if (isValidRequest)
                    {                        
                        return RedirectToAction(nameof(MyLeave));
                    }

                    ModelState.AddModelError(string.Empty, "Allocations exceeded, please verify");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
                throw;
            }

            leaveRequestCreateVM.LeaveTypes = new SelectList(
                await _leaveTypeRepository.GetAllAsync(), 
                "Id", "Name", leaveRequestCreateVM.LeaveTypeId);

            return View(leaveRequestCreateVM);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.User)]
		public async Task<IActionResult> CancelRequest(int id)
		{
			try
			{
				await _leaveRequestRepository.CancelRequest(id);
			}
			catch (Exception)
			{
				throw;
			}
			return RedirectToAction(nameof(MyLeave));
		}
	}
}
