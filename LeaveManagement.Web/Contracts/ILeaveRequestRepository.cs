using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM leaveRequestCreateVM);
        Task<EmployeeLeaveRequestViewVM> GetLeaveDetails();
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? leaveRequestId);
        Task ChangeApprovalStatus(int leaveRequestId, bool IsApproved);
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();

        Task CancelRequest(int leaveRequestId);
    }
}
