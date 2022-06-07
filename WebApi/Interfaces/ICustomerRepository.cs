using webapi.ViewModels;
using webapi.ViewModels.Customers;

namespace webapi.Interfaces
{
  public interface ICustomerRepository
  {
    public Task<List<CustomerViewModel>> ListAllCustomersAsync();
    public Task<CustomerViewModel> GetCustomerWithIdAsync(string id);
    public Task<CustomerDetailedViewModel> GetCustomerDetailsWithIdAsync(string id);
    public Task CreateCustomerAsync(PostCustomerViewModel model);
    public Task UpdateCustomerAsync(string id, PostCustomerViewModel model);
    public Task DeleteCustomerAsync(string id);
    public Task<List<CourseCustomerViewModel>> ListCustomersAndCurrentCourses();
    public Task<bool> SaveAllAsync();

  }
}