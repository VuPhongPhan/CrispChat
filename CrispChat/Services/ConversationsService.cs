using CrispChat.HttpClients;
using CrispChat.HttpClients.HttpDtos;

namespace CrispChat.Services
{
    public class ConversationsService : IConversationsService
    {
        private readonly ICrispChatHttpClient _crispChatHttpClient;

        public ConversationsService(ICrispChatHttpClient crispChatHttpClient)
        {
            _crispChatHttpClient = crispChatHttpClient;
        }

        public async Task<string> GetConversations()
        {
            var result = await _crispChatHttpClient.GetConversations();
            return result;
        }

        public async Task<string> GetMessages(string sessionId)
        {
            var result = await _crispChatHttpClient.GetMessages(sessionId);
            return result;
        }

        public Task<string> GetMetas(string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoutingAssign(string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSegments(string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetVisitor()
        {
            throw new NotImplementedException();
        }

        Task<ConversationsResponse> IConversationsService.GetConversations()
        {
            throw new NotImplementedException();
        }

        Task<MessagesResponse> IConversationsService.GetMessages(string sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
