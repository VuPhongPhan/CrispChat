using Microsoft.EntityFrameworkCore;

namespace CrispChat.Infrastructures
{
    public interface IUnitOfWork<Tcontext> : IDisposable where Tcontext : DbContext
    {
        Task<int> CommitAsync();
    }
}
