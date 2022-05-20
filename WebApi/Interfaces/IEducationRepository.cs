using webapi.Models;
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
        public void DeleteCourse(int id);
        public void UpdateCourse(int id, PostCourseViewModel model);
        public Task<List<TeacherViewModel>> ListAllTeachersAsync();
        public Task<List<CustomerViewModel>> ListAllCustomersAsync();

    }
}