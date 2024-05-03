using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.MomentoApp;


namespace Models
{
    static public class ModalsExtension
    {
        public static void ConfigureModel(this IServiceCollection services, IConfigurationManager Configuration)
        {
            services.AddDbContext<MomentosAppContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("MomentoApp")));
        }
    }
}
