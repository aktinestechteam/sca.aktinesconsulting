using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.infrastructure.Implementation;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.AutoMapper;
using sca.aktinesconsulting.repository.Implementation;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Implementation;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                        builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfigProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));
            services.AddTransient<IDatabaseConfig, DatabaseConfig>();
            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<ISCAExceptionRepository, SCAExceptionRepository>();
            services.AddTransient<ISCAExceptionService, SCAExceptionService>();
            services.AddTransient<ISCAExceptionFieldRepository, SCAExceptionFieldRepository>();
            services.AddTransient<ISCAExceptionFieldService, SCAExceptionFieldService>();
            services.AddTransient<ISCAExceptionFieldTypeRepository, SCAExceptionFieldTypeRepository>();
            services.AddTransient<ISCAExceptionFieldTypeService, SCAExceptionFieldTypeService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISCAVersionRepository, SCAVersionRepository>();
            services.AddTransient<ISCAVersionService, SCAVersionService>();
            services.AddTransient<IBookingEntryRepository, BookingEntryRepository>();
            services.AddTransient<IBookingEntryService, BookingEntryService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();



            //.AddRazorRuntimeCompilation();
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
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
