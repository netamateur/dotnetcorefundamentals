using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              IConfiguration configuration,
                              IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                 app.UseDeveloperExceptionPage();
            }


            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/wp"
            //}
            //    );
        
            //accessing static files, such as HTML etc
            app.UseStaticFiles();

            //app.UseDefaultFiles();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                //throw new Exception("Error!");

                var greeting = greeter.GetMessageOftheDay();
                //var greeting = configuration["Greeting"];
                await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //map Route - determines what controller should be instantiated.
            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
