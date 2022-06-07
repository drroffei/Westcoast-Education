using Homepage.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homepage.Pages
{
  public class RegisterNewCustomer : PageModel
  {
    private readonly ILogger<RegisterNewCustomer> _logger;
    [BindProperty]
    public PostCustomerViewModel CustomerViewModel { get; set; }
    private readonly IConfiguration _config;

    public RegisterNewCustomer(ILogger<RegisterNewCustomer> logger, IConfiguration config)
    {
      _config = config;
      _logger = logger;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
      var baseUrl = _config.GetValue<string>("baseUrl");
      using var http = new HttpClient();
      var url = $"{baseUrl}/customers";

      var response = await http.PostAsJsonAsync(url, CustomerViewModel);
      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
      }
      return RedirectToPage("RegisterNewCustomer");
    }
  }
}
