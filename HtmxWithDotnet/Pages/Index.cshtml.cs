using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxWithDotnet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public int? Id { get; set; }

        public IActionResult OnGet(int? id)
        {
            Id = id;

            if (this.HttpContext.Request.IsHtmx())
            {
                Thread.Sleep(2000);
                return Partial("IndexSubPage", new VerticalMenuModel(id, "/Index"));
            }

            return Page();
        }
    }
}
