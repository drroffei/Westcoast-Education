using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;
using webapi.ViewModels;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/v1/course")]
    public class CourseController : ControllerBase
    {
        private readonly EducationContext _context;

        public CourseController(EducationContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<List<CourseViewModel>> GetCourses()
        {
            var result = await _context.Courses.ToListAsync();
            List<CourseViewModel> listOfCourses = new List<CourseViewModel>();
            foreach (var course in result)
            {
                CourseViewModel courseVM = new CourseViewModel{
                    CourseNumber = course.CourseNumber,
                    CourseName = course.CourseName,
                    Duration = course.Duration                
                };

                listOfCourses.Add(courseVM);                
            }
            return listOfCourses;
        }

        [HttpGet("bycategory/{category}")]
        public async Task<List<CourseViewModel>> GetCoursesByCategory(string category)
        {
            var result = await _context.Courses.Where(c => c.Category.ToLower().Contains(category.ToLower())).ToListAsync();
            List<CourseViewModel> listOfCourses = new List<CourseViewModel>();
            foreach (var course in result)
            {   
                CourseViewModel courseVM = new CourseViewModel{
                    CourseNumber = course.CourseNumber,
                    CourseName = course.CourseName,
                    Duration = course.Duration                
                };

                listOfCourses.Add(courseVM);                
            }
            return listOfCourses;
        }

        [HttpPost()]
        public async Task<ActionResult> CreateCourse(PostCourseViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Input model was null");
            }
            else
            {
                Course newCourse = new Course{
                    CourseNumber = model.CourseNumber,
                    CourseName = model.CourseName,
                    Duration = model.Duration,
                    Category = model.Category,
                    Description = model.Description,
                    Details = model.Details
                };
                _context.Courses.Add(newCourse);
                await _context.SaveChangesAsync();
            }
            return Ok("Course created.");
        }
    }
}