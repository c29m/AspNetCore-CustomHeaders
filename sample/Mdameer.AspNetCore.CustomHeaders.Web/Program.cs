using Mdameer.AspNetCore.CustomHeaders.Web;

namespace Mdameer.AspNetCore.CustomHeaders.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<ICustomHeadersProvider, CustomHeadersProvider>();
            builder.Services.AddCustomHeaders(configure => { configure.Add("X-CustomHeader-Configure", "Sample Value"); });
            builder.Services.PostConfigure<CustomHeadersOptions>(o => { o.Add("X-CustomHeader-PostConfigure", "Sample Value"); });

            // Add services to the container.
            builder.Services.AddRazorPages();

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

            app.UseCustomHeaders();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}