using Homepage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homepage.Pages;

public class IndexModel : PageModel
{
  private readonly ILogger<IndexModel> _logger;
  private readonly IConfiguration _config;

  public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
  {
    _logger = logger;
    _config = config;
  }

  public async Task OnGetAsync()
  {
    
  }
}
