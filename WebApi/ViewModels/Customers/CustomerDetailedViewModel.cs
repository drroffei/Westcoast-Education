using webapi.Models;

namespace webapi.ViewModels.Customers
{
  public class CustomerDetailedViewModel
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public CourseCustomerCurrent? CurrentCourse { get; set; }
        public List<CourseCustomerFinished>? FinishedCourses { get; set; } = new List<CourseCustomerFinished>();
    }
}