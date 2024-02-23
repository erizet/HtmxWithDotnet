using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxWithDotnet.Pages
{
    [IgnoreAntiforgeryToken(Order = 2000)]
    public class ReadNameModel : PageModel
    {
        public void OnGet()
        {
        }

        public string Name { get; private set; } = "";

        public void OnPost(string name) 
        {
            Name = name;
        }
    }
}
