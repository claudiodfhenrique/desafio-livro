using Desafio.Domain.Entities;

namespace Desafio.Infrastructure.Repository.Interfaces
{
    public interface ILivroAssuntoRepository :  IRepository<LivroAssunto>
    {
        Task<IEnumerable<LivroAssunto>> ListByAsync(
            int livroCod,
            CancellationToken cancellationToken = default
        );
    }
}
