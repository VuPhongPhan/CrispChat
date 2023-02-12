using CrispChat.Entities;
namespace CrispChat.Services
{
    public interface IConversationsService
    {
        Task<bool> GetConversationsAsync(DateTime start, DateTime end);

        Task<bool> GetPeoplesAsync(DateTime start, DateTime end);

        Task<bool> GetVisitorsAsync();

        Task<bool> GetWebsite(string websiteId);

        Task HandleSyncSession();
    }
}
