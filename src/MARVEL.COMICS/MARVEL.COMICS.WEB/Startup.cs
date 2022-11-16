using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Models;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Settings;
using MARVEL.COMICS.WEB.Models;
using MARVEL.COMICS.WEB.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MARVEL.COMICS.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var section = configuration.GetSection(nameof(AppSettings));
            var appsettings = section.Get<AppSettings>();

            services.AddSingleton(appsettings);

            #region [ MODELS ]

            services.AddScoped<IUserModel, UserModel>();
            services.AddScoped<IComicModel<ComicViewModel>, ComicModel>();

            #endregion [ MODELS ]


            services.AddAuthentication("User")
                .AddCookie("User", options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(1200);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/login";
                    options.LoginPath = "/login";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
