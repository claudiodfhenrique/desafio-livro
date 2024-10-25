using Desafio.Infrastructure.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Desafio.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private IDbContextTransaction _transaction;
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        { 
            _context = context;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string GetConnectionString() => _context.Database.GetConnectionString();
    }
}
