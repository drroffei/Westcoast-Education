using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Interfaces;
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
    public async Task<ActionResult<List<CourseViewModel>>> GetCourses()
    {
      try
      {
        return Ok(await _repository.ListAllCourseAsync());
      }
      catch (System.Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpGet("bycategory/{category}")]
    public async Task<ActionResult<List<CourseViewModel>>> GetCoursesByCategory(string category)
    {
      try
      {
        return Ok(await _repository.GetCoursesByCategoryAsync(category));

      }
      catch (System.Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpGet("bycoursenumber/{coursenumber}")]
    public async Task<ActionResult<CourseViewModel>> GetCoursesByCoursenumber(int coursenumber)
    {
      try
      {
        return Ok(await _repository.GetCourseByCoursenumberAsync(coursenumber));
      }
      catch (System.Exception)
      {
        return StatusCode(500, "Internal server error");
      }
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
  }
}