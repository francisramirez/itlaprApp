using itlapr.BLL.Contract;
using itlapr.BLL.Services;
using itlapr.DAL.Interfaces;
using itlapr.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace itlapr.API.Depndencies
{
    public static class StudentDependency
    {
        public static void AddStudentDependency(this IServiceCollection services) 
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentService, StudentService>();
        }
    }
}
