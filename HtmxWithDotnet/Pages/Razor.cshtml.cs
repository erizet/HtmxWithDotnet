using Htmx;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxWithDotnet.Pages
{
    public class RazorModel : PageModel
    {
        private readonly ILogger<RazorModel> _logger;

        public RazorModel(ILogger<RazorModel> logger)
        {
            _logger = logger;
        }

        public int? Id { get; set; }

        public IActionResult OnGet(int? id)
        {
            Id = id;

            return Page();
        }
    }
}

