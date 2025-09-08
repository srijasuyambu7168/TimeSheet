using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetApp.Models
{
    public class Timesheet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "EmployeeId is required")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Hours worked is required")]
        [Range(1, 24, ErrorMessage = "Hours must be between 1 and 24")]
        public int HoursWorked { get; set; }

        [StringLength(500, ErrorMessage = "Task description cannot be longer than 500 characters")]
        public string TaskDescription { get; set; }// Navigation property
        public Employee? Employee { get; set; }
    }
}
