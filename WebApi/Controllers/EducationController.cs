using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.ViewModels;
using webapi.ViewModels.Customers;
using webapi.ViewModels.Teachers;

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

      //------------------------------|  Courses Controllers here  |------------------------------//
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
              return StatusCode(201, "Kursen har sparats i systemet");
          }
          else
          {
              return BadRequest();
          }
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Internt serverfel");
        }
      }
      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateCourse(int Id, PostCourseViewModel model)
      {
        try
        {
          await _repository.UpdateCourse(Id, model);
          if (await _repository.SaveAllAsync())
          {
            return Ok($"Course with id {Id} was updated");
          }
          else
          {
            return BadRequest();
          }          
          
        }
        catch (System.Exception)
        {          
          return StatusCode(500, "Internal server error");
        }
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteCourse(int id)
      {
        try
        {
          var statusmessage = await _repository.DeleteCourse(id);
          if (await _repository.SaveAllAsync())
          {
              return Ok(statusmessage);
          }
          else
          {
              return BadRequest(statusmessage);
          }

        }
        catch (System.Exception)
        {

            return StatusCode(500, "Internal server error");
        }
      }
      //------------------------------|  Teacher Controllers here  |------------------------------//
      [HttpGet("teachers")]
      public async Task<List<TeacherViewModel>> ListAllTeachers()
      {
        return await _repository.ListAllTeachersAsync();
      }

      [HttpGet("teachers/{id}")]
      public async Task<ActionResult<TeacherViewModel>> GetTeacherWithId(int id)
      {
        try
        {
          var teacherVM = await _repository.GetTeacherWithIdAsync(id);
          return Ok(teacherVM);
        }
        catch (System.Exception)
        {          
          return BadRequest();
        }
      }

      [HttpPost("teachers")]
      public async Task<ActionResult<TeacherViewModel>> CreateNewTeacher(PostTeacherViewModel model)
      {
        try
        {
          await _repository.CreateNewTeacherAsync(model);
          if (await _repository.SaveAllAsync())
          {
            return Ok(model);
          }
          else
          {
            return BadRequest("Unable to create new teacher");
          }
        }
        catch (System.Exception)
        {          
          return StatusCode(500, "Internal server error");
        }
      }

      [HttpPut("teachers/{id}")]
      public async Task<ActionResult> UpdateTeacher(int id, PostTeacherViewModel model)
      {
        try
        {
          await _repository.UpdateTeacherAsync(id, model);
          if (await _repository.SaveAllAsync())
          {
            return Ok(model);
          }
          return BadRequest();
        }
        catch (System.Exception)
        {
          
          return StatusCode(500,"Internal server error");
        }
      }

      [HttpDelete("teachers/{id}")]
      public async Task<ActionResult> DeleteTeacher(int id)
      {
        try
        {
          await _repository.DeleteTeacherAsync(id);
          if (await _repository.SaveAllAsync())
          {
            return Ok($"Teacher with id {id} was removed");
          }
          else
          {
            return BadRequest();
          }
        }
        catch (System.Exception)
        {          
          return StatusCode(500, "Internal server error");
        }
      }


      //------------------------------|  Customer Controllers here  |------------------------------//
      [HttpGet("customers")]
      public async Task<List<CustomerViewModel>> ListAllCustomers()
      {
        return await _repository.ListAllCustomersAsync();
      }

      [HttpGet("customers/{id}")]
      public async Task<CustomerViewModel> GetCustomerWithId(int Id)
      {
        return await _repository.GetCustomerWithIdAsync(Id);
      }

      [HttpPost("customers")]      
      public async Task<ActionResult> CreateCustomer(PostCustomerViewModel model)
      {
        try
        {
          await _repository.CreateCustomerAsync(model);

          if (await _repository.SaveAllAsync())
          {            
            return StatusCode(201, model);
          }
          else
          {
            return BadRequest();
          }
        }
        catch (System.Exception)
        {
          return StatusCode(500, "Internal server error");
        }
      }

      [HttpPut("customers/{id}")]
      public async Task<ActionResult> UpdateCustomer(int id, PostCustomerViewModel model)
      {
        try
        {
          await _repository.UpdateCustomerAsync(id, model);

          if (await _repository.SaveAllAsync())
          {
            return StatusCode(200, model);
          }
          else
          {
            return BadRequest();
          }
        }
        catch (System.Exception)
        {
          return StatusCode(500, "Internal server error");
        } 
      }

      [HttpDelete("customers/{id}")]
      public async Task<ActionResult> DeleteCustomer(int id)
      {
        try
        {
          await _repository.DeleteCustomerAsync(id);

          if (await _repository.SaveAllAsync())
          {
            return StatusCode(200, $"Customer with id {id} was removed");
          }
          else
          {
            return BadRequest();
          }
        }
        catch (System.Exception)
        {
          return StatusCode(500, "Internal server error");
        }
      }

      [HttpGet("customers/currentcourses")]
      public async Task<List<CourseCustomerCurrentViewModel>> CurrentCoursesCustomers()
      {
        return await _repository.ListCustomersAndCurrentCourses();
      }
    }
}