using itlapr.BLL.Contract;
using itlapr.BLL.Services;
using itlapr.DAL.Context;
using itlapr.DAL.Interfaces;
using itlapr.DAL.Repositories;
using itlapr.API.Depndencies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace itlapr.API
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

            //Context
            services.AddDbContext<ItlaContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("ItlaContext")));

            //Repositories
            /// services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();


            //App Services
            //services.AddTransient<IStudentService, StudentService>();


            //Dependencies
            services.AddStudentDependency();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "itlapr.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "itlapr.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
