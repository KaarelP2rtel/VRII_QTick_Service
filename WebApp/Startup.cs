using DAL.App.EF;
using DAL.App.EF.Helpers;
using DAL.App.Interfaces;
using DAL.App.Interfaces.Helpers;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using BL.Factories;
using BL.Services;
using BL.Interfaces;
using DAL.App.EF.Repositories;
using DAL.App.Interfaces.Repositories;

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
            services.AddTransient<ILocationTypeService,LocationTypeService>();
            services.AddTransient<ILocationTypeFactory, LocationTypeFactory>();
            
            services.AddTransient<IPerformerTypeService, PerformerTypeService>();
            services.AddTransient<IPerformerTypeFactory, PerformerTypeFactory>();

            services.AddTransient<IEventTypeSerivce, EventTypeService>();
            services.AddTransient<IEventTypeFactory, EventTypeFactory>();

            services.AddTransient<ITicketTypeSerivce, TicketTypeService>();
            services.AddTransient<ITicketTypeFactory, TicketTypeFactory>();

            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ILocationFactory, LocationFactory>();

            services.AddTransient<IPerformerService, PerformerService>();
            services.AddTransient<IPerformerFactory, PerformerFactory>();

            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IEventFactory, EventFactory>();

            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ILocationFactory, LocationFactory>();


            // Add uow to DI container

            services.AddSingleton<IRepositoryFactory, EFRepositoryFactory>();
            services.AddScoped<IRepositoryProvider, EFRepositoryProvider>();
            services.AddScoped<IDataContext, ApplicationDbContext>();
            services.AddScoped<IAppUnitOfWork, AppEFUnitOfWork>();

            //Special case for user repo
            services.AddScoped<IUserRepository, EFUserRepository>();




            #region Security
            services.AddAuthentication()
                .AddCookie(options => { options.SlidingExpiration = true; })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidAudience = Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Token:Key"])
                            )
                    };

                    // if you fish to modify identity (ie validate, that user is not banned)
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async (context) =>
                        {
                            // hardcoded
                            if (context.Principal.Identity.Name == "a@a.ee")
                            {
                                context.Response.StatusCode = 401;
                            }

                            // Is the user allowed into the system
                            var userManager = context.HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>();
                            var user = await userManager.FindByEmailAsync(context.Principal.Identity.Name);
                            if (user == null || user.LockoutEnd > DateTime.Now)
                            {
                                context.Response.StatusCode = 401;
                            }



                        }
                    };
                });

            #endregion

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
                c.SwaggerDoc("v1", new Info { Title = "QTick API", Version = "v1" });
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
