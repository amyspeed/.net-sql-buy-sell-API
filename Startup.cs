using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buy_and_sell_dotNetAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace buy_and_sell_dotNetAPI
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
            //this could be AddControllersWithViews if we were creating a full stack app
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            //this is where we connect the Interfaces:
            //services.AddScoped<IListingRepo, MockListingRepo>();
            services.AddScoped<IListingRepo, SQLListingRepo>();

            services.AddDbContextPool<ApplicationDBContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        "server=localhost;user=root;password=Password123;database=buy-and-sell",
                        // Replace with your server version and type.
                        mySqlOptions => mySqlOptions
                            .ServerVersion(new Version(8, 0, 21), ServerType.MySql)
                            .CharSetBehavior(CharSetBehavior.NeverAppend))
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
