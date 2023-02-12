using CrispChat.Entities;
using CrispChat.Infrastructures;
using Microsoft.EntityFrameworkCore;

namespace CrispChat.Repositories
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
    }
}
