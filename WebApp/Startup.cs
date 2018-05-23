using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using DAL.App.EF.Helpers;
using DAL.App.EF.Repositories;
using DAL.App.Interfaces;
using DAL.App.Interfaces.Helpers;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Models;
using WebApp.Services;
using BL;
using BL.Services;
using BL.Factories;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.

            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonFactory, PersonFactory>();

            // Add uow to DI container

            services.AddSingleton<IRepositoryFactory, EFRepositoryFactory>();
            services.AddScoped<IRepositoryProvider, EFRepositoryProvider>();
            services.AddScoped<IDataContext, ApplicationDbContext>();
            services.AddScoped<IAppUnitOfWork, AppEFUnitOfWork>();

            #region add xml support
            //Respect browser headers
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            });

            services.AddMvc().AddXmlSerializerFormatters();
            #endregion

            #region jsonconfiguration
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling 
                            = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
                options.SerializerSettings.PreserveReferencesHandling 
                            = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                options.SerializerSettings.Formatting 
                            = Newtonsoft.Json.Formatting.Indented;
            });
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
