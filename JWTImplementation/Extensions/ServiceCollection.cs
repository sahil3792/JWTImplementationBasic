using BusinessAccessLayer.BAL;
using BusinessAccessLayer.IBAL;

namespace JWTImplementation.Extensions
{
    public static class ServiceCollection
    {
        public static  IServiceCollection AddDataManager (this IServiceCollection services)
        {
            services.AddScoped<ILoginBAL,LoginBAL>();
            services.AddTransient<JWTService>();

            return services;
        }
    }
}
