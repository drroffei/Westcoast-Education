using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
        public CourseCustomerCurrent? CurrentCourse { get; set; }
        public List<CourseCustomerFinished>? FinishedCourses { get; set; } = new List<CourseCustomerFinished>();
    }
}