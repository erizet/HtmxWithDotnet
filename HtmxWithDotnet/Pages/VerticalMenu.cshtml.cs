using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxWithDotnet.Pages
{
    public class VerticalMenuModel : PageModel
    {
        private readonly string _baseUri;

        public VerticalMenuModel(int? id, string baseUri)
        {
            Id = id;
            _baseUri = baseUri;

            if(!_baseUri.EndsWith("/"))
                _baseUri += "/";
        }

        public int? Id { get; }

        public void OnGet()
        {
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            yield return new MenuItem("Home", "/", Id == null);

            for (int i = 1; i < 5; i++)
            {
                yield return new MenuItem("Page " + i, _baseUri + i, Id == i);
            }
        }
    }

    public class MenuItem(string text, string link, bool selected)
    {
        public string Text { get; } = text;
        public string Link { get; } = link;
        public bool Selected { get; } = selected;
    }
}
