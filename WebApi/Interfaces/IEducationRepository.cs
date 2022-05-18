using webapi.Models;
using webapi.ViewModels;

namespace webapi.Interfaces
{
    public interface IEducationRepository
    {
        public Task<List<Course>> ListAllCourseAsync();
        public Task<List<Course>> GetCoursesByCategoryAsync(string category);
        public Task CreateCourseAsync(Course model);
        public void DeleteCourse(int id);
        public void UpdateCourse(int id, Course model);
        public Task<bool> SaveAllAsync();

    }
}