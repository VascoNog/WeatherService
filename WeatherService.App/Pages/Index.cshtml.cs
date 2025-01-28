using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherService.App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<String> Cities;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Cities = new List<String>()
            {
                "Leiria", "Guimaraes", "Braga",
                "Madrid", "Kathmandu", "Jakarta",
                "Sidney", "Maputo", "FakeCity",
            };

        }
    }
}
