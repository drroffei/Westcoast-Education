using webapi.Models;
using webapi.ViewModels;
using webapi.ViewModels.Customers;
using webapi.ViewModels.Teachers;

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

    public Task<List<TeacherViewModel>> ListAllTeachersAsync();
    public Task<TeacherViewModel> GetTeacherWithIdAsync(int id);
    public Task CreateNewTeacherAsync(PostTeacherViewModel model);
    public Task UpdateTeacherAsync(int id, PostTeacherViewModel model);    
    public Task DeleteTeacherAsync(int id);

    public Task<List<CustomerViewModel>> ListAllCustomersAsync();
    public Task<CustomerViewModel> GetCustomerWithIdAsync(int id);
    public Task CreateCustomerAsync(PostCustomerViewModel model);
    public Task UpdateCustomerAsync(int id, PostCustomerViewModel model);
    public Task DeleteCustomerAsync(int id);
    public Task<List<CourseCustomerCurrentViewModel>> ListCustomersAndCurrentCourses();
  }
}