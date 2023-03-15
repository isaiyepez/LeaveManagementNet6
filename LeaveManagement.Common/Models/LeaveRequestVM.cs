using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Leave Type")]
        public LeaveTypeVM LeaveType { get; set; }

        [Display(Name = "Approved?")]
        public bool? IsApproved { get; set; }

        [Display(Name = "Cancelled?")]
        public bool IsCanceled { get; set; }

		public string EmployeeId { get; set; }
		public EmployeeListVM Employee { get; set; }
    }
}
