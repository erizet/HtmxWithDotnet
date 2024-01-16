using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxWithDotnet.Pages
{
    public class OutsideModel : PageModel
    {
        private readonly ILogger<OutsideModel> _logger;

        public OutsideModel(ILogger<OutsideModel> logger)
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
                return Partial("OutSideOOB", new VerticalMenuModel(id, "/Outside"));
            }

            return Page();
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            yield return new MenuItem("Home", "/", Id == null);

            for (int i = 1; i < 5; i++)
            {
                yield return new MenuItem("Outside " + i, "/OutSide/" + i, Id == i);
            }
        }

    }
}
