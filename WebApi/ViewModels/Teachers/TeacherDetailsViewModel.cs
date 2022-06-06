using webapi.ViewModels;

namespace WebApi.ViewModels.Teachers
{
  public class TeacherDetailsViewModel
  {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public List<SkillViewModel>? Skills { get; set; }
  }
}