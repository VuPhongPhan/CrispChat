using CrispChat.Configurations;
using CrispChat.Entities;
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

        public async Task<Website> GetConfigWebsite(string websiteId)
        {
            string url = $"v1/website/{websiteId}";
            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<WebsiteResponse>(content);
            if (data == null || data.Error == true) return null;

            return data.Data;
        }

        public async Task<List<Conversation>> GetConversations(int page, DateTime? start, DateTime? end)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/conversations/{page}?";
            if (start != null) url += $"filter_date_start={start}&";
            if (end != null) url += $"filter_date_end={end}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<ConversationResponse>(content);
            if (data == null || data.Error == true) return null;

            return data.Data;
        }

        public async Task<List<Message>> GetMessages(string sessionId)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/conversation/{sessionId}/messages";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<MessageResponse>(content);
            if (data == null || data.Error == true) return null;

            return data.Data;
        }

        public async Task<Metas> GetMetas(string sessionId)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/conversation/{sessionId}/meta";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<MetaResponse>(content);
            if (data == null || data.Error == true) return null;
            return data.Data;
        }

        public async Task<List<People>> GetPeople(int page, DateTime? start, DateTime? end)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/people/profiles/{page}?";
            if (start != null) url += $"filter_date_start={start}&";
            if (end != null) url += $"filter_date_end={end}";

            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<PeopleResponse>(content);
            if (data == null || data.Error == true) return null;

            return data.Data;
        }

        public async Task<Routing> GetRouting(string sessionId)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/conversation/{sessionId}/routing";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<RoutingResponse>(content);
            if (data == null || data.Error == true) return null;

            return data.Data;
        
        }

        public Task<string> GetSegments(string sessionId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Visitor>> GetVisitor(int page)
        {
            string url = $"v1/website/{appSettings.WebsiteId}/visitors/list/{page}";
            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<VisitorResponse>(content);
            if (data == null || data.Error == true) return null;

            return data.Data;
        }
    }
}
