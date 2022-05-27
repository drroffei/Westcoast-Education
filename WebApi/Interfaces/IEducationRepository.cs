using webapi.ViewModels;

namespace webapi.Interfaces
{
  public interface IEducationRepository
  {
    public Task<bool> SaveAllAsync();
    public Task<List<CourseViewModel>> ListAllCourseAsync();
    public Task<CourseViewModel> GetCourseByCoursenumberAsync(int courseNumber);
    public Task<List<CourseViewModel>> GetCoursesByCategoryAsync(string category);
    public Task CreateCourseAsync(PostCourseViewModel model);
    public Task<string> DeleteCourse(int id);
    public Task UpdateCourse(int id, PostCourseViewModel model);
  }
}