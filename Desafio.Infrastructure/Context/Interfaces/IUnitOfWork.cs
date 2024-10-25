namespace Desafio.Infrastructure.Context.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Dispose();
        string GetConnectionString();
    }
}
