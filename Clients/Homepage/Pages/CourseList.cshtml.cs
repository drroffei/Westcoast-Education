using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homepage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Homepage.Pages
{
  public class CourseList : PageModel
  {
    private readonly ILogger<CourseList> _logger;
    private readonly IConfiguration _config;

    [BindProperty]
    public List<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();
    [BindProperty(SupportsGet = true)]
    public string Category { get; set; }

    public CourseList(ILogger<CourseList> logger, IConfiguration config)
    {
      _config = config;
      _logger = logger;
    }

    public async Task OnGet()
    {
      var baseUrl = _config.GetValue<string>("baseUrl");
      using var http = new HttpClient();
      if (Category == "" || Category == null)
      {
        var url = $"{baseUrl}/course";
        Courses = await http.GetFromJsonAsync<List<CourseViewModel>>(url);
      }
      else
      {
        var url = $"{baseUrl}/course/bycategory/{Category}";
        Courses = await http.GetFromJsonAsync<List<CourseViewModel>>(url);
      }
    }
  }
}
