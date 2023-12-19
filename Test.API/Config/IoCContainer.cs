using Microsoft.EntityFrameworkCore;
using Test.BLL;
using Test.DAL;

namespace Test.API
{
    public static class IoCContainer
    {
        /// <summary>
        /// services registration
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
        }

        /// <summary>
        /// db context registration
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterDataService(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            services.AddDbContext<TaskDBContext>(o => o.UseInMemoryDatabase("TasksDB"));
        }
    }
}
