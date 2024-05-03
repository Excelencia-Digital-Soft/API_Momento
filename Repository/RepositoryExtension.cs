using Microsoft.Extensions.DependencyInjection;
using Repository.Concreter;
using Repository.Interfaces;


namespace Repository
{
    static public class RepositoryExtension
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAuditRepository, UserAuditRepository>();
            services.AddScoped<IUserPictureRepository, UserPictureRepository>();

        
        }
    }
}
