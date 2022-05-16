using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Interfaces;
using webapi.ViewModels;

namespace webapi.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        public Task<List<CourseViewModel>> GetCoursesByCategory()
        {
            throw new NotImplementedException();
        }
    }   
}