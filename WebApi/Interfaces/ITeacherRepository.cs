using webapi.ViewModels;
using webapi.ViewModels.Teachers;
using WebApi.ViewModels.Teachers;

namespace webapi.Interfaces
{
  public interface ITeacherRepository
  {
    public Task<List<TeacherViewModel>> ListAllTeachersAsync();
    public Task<TeacherViewModel> GetTeacherWithIdAsync(int id);
    public Task<TeacherDetailsViewModel> GetTeacherDetailsWithIdAsync(int id);
    public Task CreateNewTeacherAsync(PostTeacherViewModel model);
    public Task UpdateTeacherAsync(int id, PostTeacherViewModel model);
    public Task DeleteTeacherAsync(int id);
    public Task<bool> SaveAllAsync();

  }
}