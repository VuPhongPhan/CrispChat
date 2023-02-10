using CrispChat.HttpClients.HttpDtos;

namespace CrispChat.HttpClients
{
    public interface ICrispChatHttpClient
    {
        Task<string> GetConfigWebsite(string websiteId);

        Task<string> GetConversations();

        Task<string> GetMessages(string sessionId);

        Task<string> GetSegments(string sessionId);

        Task<string> GetRoutingAssign(string sessionId);

        Task<string> GetMetas(string sessionId);

        Task<string> GetPeople();

        Task<string> GetVisitor();
    }
}
