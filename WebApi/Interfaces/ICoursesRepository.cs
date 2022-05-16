using webapi.ViewModels;

namespace webapi.Interfaces
{
    public interface ICoursesRepository
    {
        public Task<List<CourseViewModel>> GetCoursesByCategory();
    }
}