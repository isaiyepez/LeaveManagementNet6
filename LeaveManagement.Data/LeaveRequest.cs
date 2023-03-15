using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Data
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public bool? IsApproved { get; set; }
        public bool IsCanceled { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
