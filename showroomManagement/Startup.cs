using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement
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
            services.AddDbContext<DbContextShowroom>(x => x.UseSqlServer("server=.; Database=ShrowroomDb; Integrated security=true;"));
            services.AddDbContext<ShrowroomDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DbContextShowroom>();
            //services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimPrincipalFactory>();
            //services.ConfigureApplicationCookie(A => A.LoginPath = "/accounts/login");
            //services.Configure<IdentityOptions>(x => {
            //    x.Password.RequireDigit = false;
            //    //x.SignIn.RequireConfirmedEmail = true;
            //    x.Lockout.MaxFailedAccessAttempts = 3;
            //    x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //});

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
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
