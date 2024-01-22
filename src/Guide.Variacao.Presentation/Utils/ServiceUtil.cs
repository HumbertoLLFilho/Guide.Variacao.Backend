using Guide.Variacao.Core.DataBase.Configurations;
using Guide.Variacao.Core.DataBase.Repository;
using Guide.Variacao.Domain.Services;
using Guide.Variacao.Infra.Context;

namespace Guide.Variacao.Presentation.Utils
{
    public static class ServiceUtil
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Configuration
            services.ConfigureDbContext<GuideVariacaoContext>(configuration);

            //Class services

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return services;
        }

        public static T GetMyService<T>(this IServiceProvider services) where T : class =>
            services.GetService<T>() ?? throw new ArgumentNullException(typeof(T).Name.ToString());

    }
}
