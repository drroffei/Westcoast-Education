namespace webapi.Models
{
    public class CourseCustomerCurrent
    {
        public int CourseId { get; set; }
        public string? CustomerId { get; set; }
        public Course Course { get; set; }
        public Customer Customer { get; set; }

    }
}