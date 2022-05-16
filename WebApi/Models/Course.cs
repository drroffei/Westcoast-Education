using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public int CourseNumber { get; set; }
        public string? CourseName { get; set; }
        public int Duration { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
    }
}