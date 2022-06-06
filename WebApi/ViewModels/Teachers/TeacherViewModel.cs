using webapi.Models;

namespace webapi.ViewModels
{
  public class TeacherViewModel
  {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<SkillViewModel>? Skills { get; set; }
  }
}