using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.ViewModels;
using webapi.ViewModels.Customers;

namespace webapi.Repository
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;

    public CustomerRepository(EducationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<List<CustomerViewModel>> ListAllCustomersAsync()
    {
      var response = await _context.Customers.ToListAsync();
      var listCustomerVM = new List<CustomerViewModel>();
      foreach (var customer in response)
      {
        CustomerViewModel customerVM = new CustomerViewModel
        {
          Id = customer.Id,
          FirstName = customer.FirstName,
          LastName = customer.LastName,
          Email = customer.Email,
          PhoneNumber = customer.PhoneNumber,
          Address = customer.Address
        };
        listCustomerVM.Add(customerVM);
      }

      return listCustomerVM;
    }

    public async Task<CustomerViewModel> GetCustomerWithIdAsync(string id)
    {
      var response = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
      var customerVM = _mapper.Map<CustomerViewModel>(response);
      return customerVM;
    }

    public async Task<CustomerDetailedViewModel> GetCustomerDetailsWithIdAsync(string id)
    {
      var customerResponse = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

      if (customerResponse == null)
      {
        throw new Exception($"Hittade ingen kund med id: {id}");
      }
      var currentCoursesResponse = await _context.CourseCustomerCurrent.ToListAsync();
      var finishedCoursesResponse = await _context.CourseCustomerFinished.ToListAsync();

      var customerVM = _mapper.Map<CustomerDetailedViewModel>(customerResponse);

      var currentCourseToAdd = currentCoursesResponse.FirstOrDefault(c => c.CustomerId == customerVM.Id);      
      var finishedCoursesToAdd = finishedCoursesResponse.Where(c => c.CustomerId == customerVM.Id).ToList();

      if (currentCourseToAdd != null)
      {
        customerVM.CurrentCourse = currentCourseToAdd;
      }

      if (finishedCoursesToAdd != null)
      {
        customerVM.FinishedCourses.AddRange(finishedCoursesToAdd);        
      }

      
      return customerVM;
    }

    public async Task CreateCustomerAsync(PostCustomerViewModel model)
    {
      var customerToAdd = _mapper.Map<Customer>(model);
      await _context.Customers.AddAsync(customerToAdd);
    }

    public async Task UpdateCustomerAsync(string id, PostCustomerViewModel model)
    {
      var customer = await _context.Customers.FindAsync(id);
      if (customer == null)
      {
        return;
      }
      _mapper.Map<PostCustomerViewModel, Customer>(model, customer);

      _context.Customers.Update(customer);
    }

    public async Task DeleteCustomerAsync(string id)
    {
      var response = await _context.Customers.FindAsync(id);
      if (response == null)
      {
        return;
      }
      _context.Customers.Remove(response);
    }

    public async Task<List<CourseCustomerViewModel>> ListCustomersAndCurrentCourses()
    {
      var response = await _context.CourseCustomerCurrent.Include(c => c.Customer).Include(c => c.Course).ToListAsync();
      List<CourseCustomerViewModel> listCCVM = new List<CourseCustomerViewModel>();

      foreach (var courseCustomer in response)
      {
        var course = courseCustomer.Course;
        var customer = courseCustomer.Customer;

        listCCVM.Add(
          new CourseCustomerViewModel
          {
            CourseNumber = course.CourseNumber,
            CourseName = course.CourseName,
            CustomerFirstname = customer.FirstName,
            CustomerLastName = customer.LastName
          }
        );
      };

      return listCCVM;
    }

    
    public async Task<bool> SaveAllAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
  }
}