using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.ViewModels;
using webapi.ViewModels.Customers;

namespace webapi.Interfaces
{
  public interface ICustomerRepository
  {
    public Task<List<CustomerViewModel>> ListAllCustomersAsync();
    public Task<CustomerViewModel> GetCustomerWithIdAsync(int id);
    public Task CreateCustomerAsync(PostCustomerViewModel model);
    public Task UpdateCustomerAsync(int id, PostCustomerViewModel model);
    public Task DeleteCustomerAsync(int id);
    public Task<List<CourseCustomerCurrentViewModel>> ListCustomersAndCurrentCourses();
    public Task<bool> SaveAllAsync();

  }
}