using CrispChat.Configurations;
using CrispChat.HttpClients;

namespace CrispChat.Extensions
{
    public static class HttpClientExtentions
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

            services.ConfigurationCrispChatHttpClient(appSettings);

        }

        private static void ConfigurationCrispChatHttpClient(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient<ICrispChatHttpClient, CrispChatHttpClient>("crisp-chat", (sp, cl) =>
            {
                cl.BaseAddress = new Uri(appSettings.CrispchatUrl);
                cl.DefaultRequestHeaders.Add("Accept", "application/json");
                cl.DefaultRequestHeaders.Add("X-Crisp-Tier", "plugin");
                cl.DefaultRequestHeaders.Add("Authorization", $"Basic {appSettings.Token}");
            });

            services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("crisp-chat"));
        }
    }
}
