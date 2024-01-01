using DataStore.MySQLConnector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace ESchool.Startup
{
    public static class DependencyIncjection
    {
        public static IServiceCollection RegistedServices(this IServiceCollection services)
        {

          


            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:5000",
                                                          "http://localhost:5001");
                                  });
            });
            return services;
        }
    }
}
