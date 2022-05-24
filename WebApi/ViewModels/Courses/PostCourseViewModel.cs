using System.ComponentModel.DataAnnotations;

namespace webapi.ViewModels
{
    public class PostCourseViewModel
    {
      [Required]
      public int CourseNumber { get; set; }
      [Required]
      public string? CourseName { get; set; }
      [Required]
      public int Duration { get; set; }
      [Required]
      public string? Category { get; set; }
      [Required]
      public string? Description { get; set; }
      [Required]
      public string? Details { get; set; }
      [Required]
      public int TeacherId { get; set; }
    }
}