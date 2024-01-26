using HtmxWithDotnet.Pages;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HtmxWithDotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddRazorComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapGet("api/razor/{id:int?}", (int? id) => {
                return new RazorComponentResult<MyRazorComponent>(new { Id = id, BaseUri = "/api/razor/" });
            });
            app.MapRazorPages();

            app.Run();
        }
    }
}
