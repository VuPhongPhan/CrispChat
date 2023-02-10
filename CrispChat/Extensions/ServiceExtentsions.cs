using CrispChat.Configurations;
using CrispChat.HttpClients;
using CrispChat.Persistence;
using CrispChat.Services;
using Microsoft.EntityFrameworkCore;

namespace CrispChat.Extensions
{
    public static class ServiceExtentsions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(c => c.AddProfile(new MappingProfile()));
            services.ConfigureSettings(configuration);
            services.ConfigureServices();
            services.ConfigureDbContext(configuration);

            return services;
        }

        private static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CrispChatContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                    builder => builder.MigrationsAssembly(typeof(CrispChatContext).Assembly.FullName));
            });

            services.AddScoped<CrispChatContext>();

            return services;
        }

        private static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

            services.AddSingleton(appSettings);

            return services;
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICrispChatHttpClient, CrispChatHttpClient>();
            services.AddTransient<IConversationsService, ConversationsService>();

            //repository

            return services;
        }
    }
}
