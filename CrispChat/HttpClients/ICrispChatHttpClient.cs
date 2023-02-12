using CrispChat.Entities;
using CrispChat.HttpClients.HttpDtos;

namespace CrispChat.HttpClients
{
    public interface ICrispChatHttpClient
    {
        Task<Website> GetConfigWebsite(string websiteId);

        Task<List<Conversation>> GetConversations(int page, DateTime? start, DateTime? end);

        Task<List<Message>> GetMessages(string sessionId);

        Task<string> GetSegments(string sessionId);

        Task<Routing> GetRouting(string sessionId);

        Task<Metas> GetMetas(string sessionId);

        Task<List<People>> GetPeople(int page, DateTime? start, DateTime? end);

        Task<List<Visitor>> GetVisitor(int page);
    }
}
