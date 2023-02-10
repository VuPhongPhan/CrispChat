using Microsoft.EntityFrameworkCore;

namespace CrispChat.Infrastructures
{
    public class UnitOfWork<Tcontext> : IUnitOfWork<Tcontext> where Tcontext : DbContext
    {
        private readonly Tcontext _context;

        public UnitOfWork(Tcontext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync() => _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
