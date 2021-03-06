using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.ViewModels;
using webapi.ViewModels.Customers;

namespace webapi.Controllers
{
  [ApiController]
  [Route("api/v1/customers")]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerRepository _repository;
    public CustomerController(ICustomerRepository repository)
    {
      _repository = repository;
    }

    [HttpGet()]
      public async Task<ActionResult<List<CustomerViewModel>>> ListAllCustomers()
      {
        try
        {
          return Ok(await _repository.ListAllCustomersAsync());          
        }
        catch (System.Exception)
        {
          return StatusCode(500, "Internal server error");
        }
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<CustomerViewModel>> GetCustomerWithId(string id)
      {
        try
        {
          return Ok(await _repository.GetCustomerWithIdAsync(id));
        }
        catch (System.Exception)
        {          
          return StatusCode(500, "Internal server error");
        }
      }

      [HttpGet("details/{id}")]
      public async Task<ActionResult<CustomerDetailedViewModel>> GetCustomerDetailsWithId(string id)
      {
        try
        {
          return Ok(await _repository.GetCustomerDetailsWithIdAsync(id));
        }
        catch (System.Exception)
        {          
          return StatusCode(500, "Internal server error");
        }
      }

      [HttpPost()]      
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

      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateCustomer(string id, PostCustomerViewModel model)
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

      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteCustomer(string id)
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

      [HttpGet("currentcourses")]
      public async Task<ActionResult<List<CourseCustomerViewModel>>> CurrentCoursesCustomers()
      {
        try
        {
          return Ok(await _repository.ListCustomersAndCurrentCourses());
          
        }
        catch (System.Exception)
        {          
          return StatusCode(500, "Internal server error");
        }
      }

  }
}