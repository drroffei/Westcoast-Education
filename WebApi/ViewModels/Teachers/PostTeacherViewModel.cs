using System.ComponentModel.DataAnnotations;

namespace webapi.ViewModels.Teachers
{
  public class PostTeacherViewModel
  {
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
    [Required]
    public string? TeacherSkill { get; set; }
  }
}