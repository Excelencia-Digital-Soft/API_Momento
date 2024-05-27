using Domain;
using Microsoft.Extensions.DependencyInjection;
using Services.Concreter;
using Services.Interfaces;

namespace Services
{
    static public class ServiceExtension
    {
        public static void ConfigureService(this IServiceCollection services)
        {

            services.AddScoped<ILoginServices,LoginServices>();
            services.AddScoped<ILoginServices,LoginServices>();
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IExceptionsServices, ExceptionsServices>();
            services.AddScoped<IPostsServices, PostsServices>();
            
        }
    }
}
