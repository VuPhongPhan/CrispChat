using CrispChat.Backgrounds;
using CrispChat.Configurations;
using CrispChat.HttpClients;
using CrispChat.Infrastructures;
using CrispChat.Repositories;
using CrispChat.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CrispChat.Extensions
{
    public static class ServiceExtentsions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(c => c.AddProfile(new MappingProfile()));
            services.ConfigureSettings(configuration);
            services.ConfigureServices();
            services.ConfigureMongoDbClient();

            return services;
        }
        

        private static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            var databaseSettings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();

            services.AddSingleton(appSettings);
            services.AddSingleton(databaseSettings);

            return services;
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // httpcleint
            services.AddTransient<ICrispChatHttpClient, CrispChatHttpClient>();
            
            // service
            services.AddTransient<IConversationsService, ConversationsService>();


            //repository
            services.AddTransient<IConversationRepository, ConversationRepository>();
            services.AddTransient<IPeopleRepository, PeopleRepository>();
            services.AddTransient<IWebsiteRepository, WebsiteRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IMetaRepository, MetaRepository>();
            services.AddTransient<IRoutingRepository, RoutingRepository>();
            services.AddTransient<ISegmentRepository, SegmentRepository>();
            services.AddTransient<IVisitorRepository, VisitorRepository>();

            // background
            services.AddHostedService<SynsDataSessionWorker>();
            services.AddHostedService<SynsConversationsWorker>();

            return services;
        }
        public static void ConfigureMongoDbClient(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(new MongoClient(services.GetMongoConnectionString()))
                .AddScoped(x => x.GetService<IMongoClient>()?.StartSession());
        }
        private static string GetMongoConnectionString(this IServiceCollection services)
        {
            var settings = services.GetOptions<DatabaseSettings>(nameof(DatabaseSettings));
            if (settings == null || string.IsNullOrEmpty(settings.ConnectionString))
            {
                throw new ArgumentNullException("DatabaseSetting is not configure");
            }
            var databaseName = settings.DatabaseName;
            var connectionString = settings.ConnectionString + "/" + databaseName;

            return connectionString;
        }
    }
}
