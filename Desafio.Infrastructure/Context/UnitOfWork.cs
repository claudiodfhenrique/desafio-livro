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

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            return _transaction;
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (ExistActiveTransaction())
            {
                await _transaction.CommitAsync(cancellationToken);
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (ExistActiveTransaction())
            {
                await _transaction.RollbackAsync(cancellationToken);
                _transaction.Dispose();
                _transaction = null;
            }
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

        private bool ExistActiveTransaction()
        {
            return _transaction is not null && _context.Database.CurrentTransaction is not null;
        }

        public string GetConnectionString() => _context.Database.GetConnectionString();
    }
}
