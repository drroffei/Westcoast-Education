using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.ViewModels;
using webapi.ViewModels.Teachers;

namespace webapi.Controllers
{
  [ApiController]
  [Route("api/v1/teachers")]
  public class TeacherController : ControllerBase
  {
    private readonly ITeacherRepository _repository;
    public TeacherController(ITeacherRepository repository)
    {
      _repository = repository;
    }

    [HttpGet()]
    public async Task<ActionResult<List<TeacherViewModel>>> ListAllTeachers()
    {
      try
      {
        return Ok(await _repository.ListAllTeachersAsync());
      }
      catch (System.Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpGet("/{id}")]
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

    [HttpPost()]
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

    [HttpPut("/{id}")]
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

        return StatusCode(500, "Internal server error");
      }
    }

    [HttpDelete("/{id}")]
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
  }
}