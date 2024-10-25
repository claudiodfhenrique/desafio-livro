using Desafio.Domain.Entities;
using Desafio.Infrastructure.Queries.ViewModel;

namespace Desafio.Infrastructure.Queries.Interfaces
{
    public interface IQueryFacadeAssunto : IQueryFacade<Assunto>
    {
        Task<AssuntoViewModel> FirstAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<AssuntoViewModel>> ListAsync(CancellationToken cancellationToken = default);
    }
}
