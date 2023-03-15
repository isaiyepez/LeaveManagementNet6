using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace LeaveManagement.Common.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [Required]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		[Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Required]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		[Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        public SelectList? LeaveTypes { get; set; }

        [Display(Name = "Request Comments")]
        public string? RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The start date must be minor than the end date",
                    new[] { 
                        nameof(StartDate), 
                        nameof(EndDate) 
                    });
            }
        }
    }
}
