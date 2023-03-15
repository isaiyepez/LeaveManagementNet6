using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.BusinessLogic.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM leaveRequestCreateVM);
        Task<EmployeeLeaveRequestViewVM> GetLeaveDetails();
        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? leaveRequestId);
        Task ChangeApprovalStatus(int leaveRequestId, bool IsApproved);
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();

        Task CancelRequest(int leaveRequestId);
    }
}
