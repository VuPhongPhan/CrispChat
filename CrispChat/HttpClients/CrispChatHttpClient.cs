using CrispChat.Configurations;
using CrispChat.HttpClients.HttpDtos;
using System.Text.Json;

namespace CrispChat.HttpClients
{
    public class CrispChatHttpClient : ICrispChatHttpClient
    {
        private readonly HttpClient _client;
        private readonly AppSettings appSettings;

        public CrispChatHttpClient(HttpClient httpClient, AppSettings appSettings)
        {
            _client = httpClient;
            this.appSettings = appSettings;
        }

        public Task<string> GetConfigWebsite(string websiteId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetConversations()
        {
            string url = $"v1/website/{appSettings.WebsiteId}/conversations";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetMessages(string sessionId)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/conversation/{sessionId}/messages";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetMetas(string sessionId)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/conversation/{sessionId}/meta";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> GetPeople()
        {
            string url = $"v1/website/{appSettings.WebsiteId}/people/profiles";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> GetRoutingAssign(string sessionId)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/conversation/{sessionId}/routing";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            return result;
        
        }

        public Task<string> GetSegments(string sessionId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetVisitor()
        {
            string url = $"v1/website/{appSettings.WebsiteId}/visitors/list";
            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
