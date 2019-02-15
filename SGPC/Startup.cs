using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using AccountCore.ServiceInjects;
using AccountCore.Repositories.Interfaces;
using AccountCore.DataModels;
using EF.dbmodel;
using Database.Services.Repository.UnitsOfWork;
using AccountCore.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace SGPC
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

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 100;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
                //


            });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/Login";
                options.SlidingExpiration = true;
            });
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();

			AutoMapper.Mapper.Initialize(cfg => {

				cfg.AddProfile<Helpers.Mapper>();
			});

			//    services.AddDbContext<dbcontext>(options =>
			//options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			//    services.AddSingleton<IFileProvider>(
			//        new PhysicalFileProvider(
			//            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

			services.AddIdentity<ApplicationUsers, ApplicationRoles>()
                 .AddEntityFrameworkStores<dbcontext>()
                .AddDefaultTokenProviders();


            services.AddAuthorization();
            services.AddDbContext<dbcontext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountManager, AccountManager>();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pa-IN");
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc();
            services.AddAccountManager();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Account/Login");
            }

            app.UseStaticFiles();

            IList<CultureInfo> supportedCultures = new List<CultureInfo> { new CultureInfo("pa-IN"), new CultureInfo("pa-IN") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pa-IN"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });


            app.Use((context, next) =>
            {
                var culture = new CultureInfo("pa-IN");
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
                // Call the next delegate/middleware in the pipeline
                return next();
            });
            app.UseAuthentication();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
            CreateRoles(serviceProvider).Wait();
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            try
            {
                var accountManager = serviceProvider.GetRequiredService<IAccountManager>();
                string[] roleNames = { "Admin", "User" };
                foreach (var roleName in roleNames)
                {
                    //creating the roles and seeding them to the database
                    var roleExist = await accountManager.GetRoleByNameAsync(roleName);
                    if (roleExist == null)
                    {
                        ApplicationRoles applicationRoles = new ApplicationRoles(roleName);
                        applicationRoles.Name = roleName;
                        var roleResult = await accountManager.CreateRoleAsync(applicationRoles, null);
                    }
                }
            }
            catch (Exception ex)
            {
                var e = ex;
            }
        }
    }
}
