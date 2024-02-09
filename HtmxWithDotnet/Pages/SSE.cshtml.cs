using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Text;

namespace HtmxWithDotnet.Pages
{
    public class SSEModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetConnect()
        {
            Response.StatusCode = 200;
            Response.Headers?.Append("Cache-Control", "no-cache");
            Response.Headers?.Append("Connection", "keep-alive");
            Response.Headers?.Append("Content-Type", "text/event-stream");

            StreamWriter streamWriter = new StreamWriter(Response.Body);

            while (!HttpContext.RequestAborted.IsCancellationRequested)
            {
                var html = string.Format("<h3>The product code is: {0}</h3>", Guid.NewGuid().ToString());

                var stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat("data: {0}\n\n", html);
                await streamWriter.WriteAsync(stringBuilder.ToString());
                await streamWriter.FlushAsync();
                await Task.Delay(1000, HttpContext.RequestAborted);
            }

            return new OkResult();
        }

    }
}
