using CrispChat.HttpClients.HttpDtos;

namespace CrispChat.Services
{
    public interface IConversationsService
    {
        Task<ConversationsResponse> GetConversations();

        Task<MessagesResponse> GetMessages(string sessionId);

        Task<string> GetSegments(string sessionId);

        Task<string> GetRoutingAssign(string sessionId);

        Task<string> GetMetas(string sessionId);

        Task<string> GetPeople();

        Task<string> GetVisitor();
    }
}
