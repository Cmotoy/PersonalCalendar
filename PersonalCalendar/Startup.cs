using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalCalendar.data.DatabaseContext.ApplicationDbContext;
using PersonalCalendar.data.DatabaseContext.AuthenticationDbContext;
using PersonalCalendar.data.Entities;
using PersonalCalendar.Interfaces;
using PersonalCalendar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCalendar
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
            services.AddSingleton <IScheduleServices, ScheduleServices>();


            services.AddDbContextPool<AuthenticationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString
                ("AuthenticationConnection"),

                sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("PersonalCalendar.data");
                }));

            services.AddDbContextPool<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString
                ("AuthenticationConnection"),


                sqlServerOptions =>
                {
                sqlServerOptions.MigrationsAssembly("PersonalCalendar.data");
                }));
                 
            services.AddControllersWithViews();
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
       
        public void MigrateDatabaseContext(IApplicationBuilder app)
        {
            var AuthenticationDbContext = app.ApplicationServices.GetRequiredService<AuthenticationDbContext>();
            AuthenticationDbContext.Database.Migrate();

            var ApplicationDbContext = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            ApplicationDbContext.Database.Migrate();
        }        
    }
}
