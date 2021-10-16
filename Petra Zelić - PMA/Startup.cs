
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Petra_Zelić___PMA.DbModels;
using Petra_Zelić___PMA.Models;
using Petra_Zelić___PMA.Services;
using Petra_Zelić___PMA.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Petra_Zelić___PMA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //referenca na bazu
        private void SetupDbContext(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("pma");
            services.AddDbContext<MOVIEContext>(options => options.UseSqlServer(connString));  
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();  
            services.AddControllersWithViews();

            services.AddScoped<ZanrService>();
            services.AddScoped<ZanrRepository>();
            services.AddScoped<RedateljService>();
            services.AddScoped<RedateljRepository>();
            services.AddScoped<FilmService>();
            services.AddScoped<FilmRepository>();

            SetupDbContext(services);
            // ne oristimo sql server nego direkno memoriju racunala -> mana; nakon gasenja app podaci o prijavljenima se gube
            services.AddDbContext<AppDb>(config =>
            {
                config.UseInMemoryDatabase("Memory");
            });
            services.AddIdentity<IdentityUser, IdentityRole>(config => {
                config.Password.RequiredLength = 7;
                config.Password.RequireDigit = true;
                config.Password.RequireNonAlphanumeric = true;
                config.Password.RequireUppercase = true;
                config.Password.RequireLowercase = true;
            }).AddEntityFrameworkStores<AppDb>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "PMA_Film_Cookie";
                config.LoginPath = "/Home/Login";  
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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
            CreateAdmin(serviceProvider).Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Film",
                    pattern: "film",
                    defaults: new { controller = "Film", action = "Film" }); 

                endpoints.MapControllerRoute(
                   name: "Zanr",
                   pattern: "zanr",
                   defaults: new { controller = "Zanr", action = "Zanr" });

                endpoints.MapControllerRoute(
                   name: "Redatelj",
                   pattern: "redatelj",
                   defaults: new { controller = "Redatelj", action = "Redatelj" });
            });
        }

        private async Task CreateAdmin(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "User", "Visitor" }; //moze ih bit više, manje; nama je bitan samo admin
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //ako ne postoji uloga spremljena u bazu tj. memoriju onda je stvaramo i spremamo asinkrono
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var admin = new IdentityUser
            {
                UserName = "pzelic",
                Email = "pzelic@pmfst.hr",
            };
            string adminpassword = "Petr@123";
            var _adminuser = await UserManager.FindByEmailAsync("pzelic@pmfst.hr");

            if (_adminuser == null)
            {
                var createadmin = await UserManager.CreateAsync(admin, adminpassword);
                if (createadmin.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
