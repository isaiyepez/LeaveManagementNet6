using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.BusinessLogic.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
        Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);
        Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeID);
        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int employeeId);

        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model);
    }
}
