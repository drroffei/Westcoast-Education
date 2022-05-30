using webapi.ViewModels;
using WebApi.ViewModels.Courses;

namespace webapi.Interfaces
{
  public interface IEducationRepository
  {
    public Task<bool> SaveAllAsync();
    public Task<List<CourseViewModel>> ListAllCourseAsync();
    public Task<CourseDetailedViewModel> GetCourseByCoursenumberAsync(int courseNumber);
    public Task<List<CourseViewModel>> GetCoursesByCategoryAsync(string category);
    public Task CreateCourseAsync(PostCourseViewModel model);
    public Task<string> DeleteCourse(int id);
    public Task UpdateCourse(int id, PostCourseViewModel model);
  }
}