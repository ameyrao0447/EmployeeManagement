using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Employee
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration config)
        {
            configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDb>(options => options.UseSqlServer(configuration.GetConnectionString("EmployeesCon")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<IEmployee, SqlDataManip>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
