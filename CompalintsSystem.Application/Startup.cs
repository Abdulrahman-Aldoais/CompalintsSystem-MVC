using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.EF.Configuration;
using CompalintsSystem.EF.Repositories;
using CompalintsSystem.Core.Hubs;
using CompalintsSystem.Core.Models;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using System;
using System.Net;

namespace CompalintsSystem.Application
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


            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                //options.ExcludedHosts.Add("example.com");
                //options.ExcludedHosts.Add("www.example.com");
            });

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
            //    options.HttpsPort = 5001;
            //});

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            //services.AddControllersWithViews()
            //   .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.ConfigureApplicationCookie(config =>
            {

                config.Cookie.Name = "MyCookie";
                config.LoginPath = "/Account/Login";
                config.AccessDeniedPath = new PathString("/Account/AccessDenied");

            });
            services.AddDbContext<AppCompalintsContextDB>(
        b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
              //.UseLazyLoadingProxies()
              );

            //services.Configure<IdentityOptions>(opts =>
            //{
            //    opts.User.RequireUniqueEmail = true;
            //    opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
            //    opts.Password.RequiredLength = 8;
            //    opts.Password.RequireNonAlphanumeric = true;
            //    opts.Password.RequireLowercase = false;
            //    opts.Password.RequireUppercase = true;
            //    opts.Password.RequireDigit = true;

            //    //opts.SignIn.RequireConfirmedEmail = true;

            //    opts.Lockout.AllowedForNewUsers = true;
            //    opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            //    opts.Lockout.MaxFailedAccessAttempts = 3;
            //});


            // Add services to the container.
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICompalintRepository, CompalintRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IManagementUsers, ManagementUsers>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddIdentity<ApplicationUser, IdentityRole>(
     options => options.SignIn.RequireConfirmedAccount = true)
     .AddEntityFrameworkStores<AppCompalintsContextDB>()
    .AddDefaultTokenProviders();


            //services.AddAdminServices();
            services.AddSignalR();


            // Add services to the container.

            //services.AddCustomConfiguredAutoMapper();

            services.AddAutoMapper(typeof(Startup));



            //services.AddMemoryCache();
            //services.AddSession();

           // add toastnotify
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNToastNotifyNoty(new NToastNotify.NotyOptions()
                {
                    ProgressBar = true,
                    Timeout = 5000,
                    Theme = "sunset"
                });
            services.AddRazorPages();



        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseNToastNotify();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //Http >> Https 
            app.UseHttpsRedirection();
            app.UseStaticFiles();


           // app.UseSession();


            //Authentication & Authorization



            app.UseAuthentication();
            //Account/Login            >> Url , Route.
            //Posts/Detials/5/11/2020

            app.UseRouting();
            //app.UseMiddleware<GetRoutingMiddleware>();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<NotefcationHub>("/notefy");
            });



            UsersConfiguration.SeedUsersAndRolesAsync(app).Wait();


            RotativaConfiguration.Setup("wwwroot");



        }
    }
}
