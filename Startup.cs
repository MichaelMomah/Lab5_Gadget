using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Lab5_Gadgets.Models;

namespace Lab5_Gadgets
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Here, we disable endpoint routing. This was an issue when upgrading from ASP.NET CORE 2.0 to ASP.NET Core 3.0
            services.AddMvc(options => options.EnableEndpointRouting = false);


            //Adding connection
            string connection = @"Server=(localdb)\mssqllocaldb;Database=gadgetDB;Trusted_Connection=True;ConnectRetryCount=0";


            //Adding Db Context
            services.AddDbContext<GadgetContext>(options => options.UseSqlServer(connection));
            
            /*
             
               To create database, go to tools --> Nu-Get Package Manager --> Package Manager Console --> type in command: Add-Migration InitialCreate
               MAKE SURE YOU install the Microsoft.EntityFramework.Tools from the Nu-Get package manager first.
               You should now see a directory named migrations in your solution explorer.
               Once you see the folder (directory) named migration. Go back to your Package Manager Console.
               Input: Update-Database.
               Go to View --> SQL Server Object Explorer, you should see the new DB!

            */

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
