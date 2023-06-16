using CompalintsSystem.Core.Hubs;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.EF.Configuration;
using CompalintsSystem.EF.DataBase;
using CompalintsSystem.EF.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using System;

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


            //  ›⁄Ì· Œ«’Ì… HSTS (HTTP Strict Transport Security) ›Ì «· ÿ»Ìﬁ
            services.AddHsts(options =>
            {
                options.Preload = true; //  ›⁄Ì· preload ·‹ HSTS
                options.IncludeSubDomains = true; //  ›⁄Ì· includeSubDomains ·‹ HSTS
                options.MaxAge = TimeSpan.FromDays(60); //  ⁄ÌÌ‰ MaxAge ·‹ HSTS
            });

            //  ›⁄Ì· ‰Ÿ«„ «·„’«œﬁ… ›Ì «· ÿ»Ìﬁ Ê ÕœÌœ «·√œÊ«— «·„’—Õ »Â« ·ﬂ· ”Ì«”…
            services.AddAuthorization(options =>
            {
                // ≈÷«›… ”Ì«”… «·„’«œﬁ… "AdminPolicy" Ê ÕœÌœ «·√œÊ«— «·„’—Õ »Â«
                options.AddPolicy("AdminPolicy", policy =>
                    policy.RequireRole("AdminGeneralFederation"));
                // ≈÷«›… ”Ì«”… «·„’«œﬁ… "BeneficiariePolicy" Ê ÕœÌœ «·√œÊ«— «·„’—Õ »Â«
                options.AddPolicy("BeneficiariePolicy", policy =>
                    policy.RequireRole("Beneficiarie"));
            });

            //  ›⁄Ì· ‰Ÿ«„ «·„’«œﬁ… »«” Œœ«„ «·ﬂÊﬂÌ“ Ê ÕœÌœ Œ’«∆’ „·› «·ﬂÊﬂÌ“
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "MyCookie"; //  ÕœÌœ «”„ „·› «·ﬂÊﬂÌ“
                config.LoginPath = "/Account/Login"; //  ÕœÌœ „”«— «·œŒÊ·
                config.AccessDeniedPath = new PathString("/Account/AccessDenied"); //  ÕœÌœ „”«— «·Ê’Ê· «·„—›Ê÷
            });

            //  ›⁄Ì· ﬁ«⁄œ… «·»Ì«‰«  ›Ì «· ÿ»Ìﬁ Ê ÕœÌœ «·”·”·… «·„ ’·… «·«› —«÷Ì…
            services.AddDbContext<AppCompalintsContextDB>(b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


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



            app.UseRouting();

            UsersConfiguration.SeedUsersAndRolesAsync(app).Wait();


            RotativaConfiguration.Setup("wwwroot");



        }
    }
}
