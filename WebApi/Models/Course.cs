using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
  public class Course
  {
    [Key]
    public int CourseId { get; set; }
    [Required]
    public int CourseNumber { get; set; }
    [Required]
    public string? CourseName { get; set; }
    [Required]
    public string? Duration { get; set; }
    [Required]
    public string? Category { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public string? Details { get; set; }
    public List<CourseCustomerCurrent>? CurrentCustomers { get; set; } = new List<CourseCustomerCurrent>();
    public List<CourseCustomerFinished>? FinishedCustomers { get; set; } = new List<CourseCustomerFinished>();
    public int TeacherId { get; set; }
    [ForeignKey("TeacherId")]
    public Teacher? Teacher { get; set; } = new Teacher();
  }
}