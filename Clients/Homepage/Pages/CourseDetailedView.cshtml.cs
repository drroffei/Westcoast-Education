using Homepage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homepage.Pages
{
  public class CourseDetailedView : PageModel
  {
    private readonly ILogger<CourseDetailedView> _logger;
    private readonly IConfiguration _config;
    [BindProperty]
    public CourseDetailedViewModel Course { get; set; }

    public CourseDetailedView(ILogger<CourseDetailedView> logger,IConfiguration config)
    {
      _config = config;
      _logger = logger;
    }

    public async Task OnGet(int id)
    {
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/course/bycoursenumber/{id}";
      using var http = new HttpClient();
      Course = await http.GetFromJsonAsync<CourseDetailedViewModel>(url);
    }
  }
}
