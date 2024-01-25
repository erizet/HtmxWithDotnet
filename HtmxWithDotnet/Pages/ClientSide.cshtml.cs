using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxWithDotnet.Pages
{
    public class ClientSideModel : PageModel
    {
        private readonly ILogger<ClientSideModel> _logger;

        public ClientSideModel(ILogger<ClientSideModel> logger)
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
                return new ContentResult()
                {
                    ContentType = "text/html",
                    Content = $"<h1 id=\"theId\">{this.Id}</h1>"
                };
            }

            return Page();
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            yield return new MenuItem("Home", "/ClientSide", Id == null);

            for (int i = 1; i < 5; i++)
            {
                yield return new MenuItem("ClientSide " + i, "/ClientSide/" + i, Id == i);
            }
        }

    }
}
