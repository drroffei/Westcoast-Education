using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.ViewModels;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/v1/education")]
    public class EducationController : ControllerBase
    {
        private readonly EducationContext _context;
        private readonly IEducationRepository _repository;

        public EducationController(EducationContext context, IEducationRepository repository)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet()]
        public async Task<List<CourseViewModel>> GetCourses()
        {            
            return await _repository.ListAllCourseAsync();
        }

        [HttpGet("bycategory/{category}")]
        public async Task<List<CourseViewModel>> GetCoursesByCategory(string category)
        {
            return await _repository.GetCoursesByCategoryAsync(category);
        }

        [HttpGet("bycoursenumber/{coursenumber}")]
        public async Task<CourseViewModel> GetCoursesByCoursenumber(int coursenumber)
        {
            return await _repository.GetCourseByCoursenumberAsync(coursenumber);
        }

        [HttpPost()]
        public async Task<ActionResult> CreateCourse(PostCourseViewModel model)
        {
            try
            {
                await _repository.CreateCourseAsync(model);
                
                if (await _repository.SaveAllAsync())
                {
                    return StatusCode(201, "Bilen har sparats i systemet");                
                }
                else{
                    return BadRequest();
                }                
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internt serverfel");
            }            
        }

        [HttpGet("/teachers")]
        public async Task<List<TeacherViewModel>> ListAllTeachers()
        {
            return await _repository.ListAllTeachersAsync();
        }
        [HttpGet("/teachers")]
        public async Task<List<CustomerViewModel>> ListAllCustomers()
        {
            return await _repository.ListAllCustomersAsync();
        }
    }
}