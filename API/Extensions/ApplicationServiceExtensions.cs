

using API.Controllers.Interfaces;
using API.Controllers.Repositories;
using ChatMicroservice.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
           
           
            services.AddControllers();
          
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IChoiceRepository, ChoiceRepository>();
           
            services.AddDbContext<DataContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

           
            services.AddSignalR();



            return services;
        }
    }
}