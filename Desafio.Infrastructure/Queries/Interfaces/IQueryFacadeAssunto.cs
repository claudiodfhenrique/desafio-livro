using Desafio.Application.Queries.Assuntos.ViewModel;
using Desafio.Domain.Entities;

namespace Desafio.Infrastructure.Queries.Interfaces
{
    public interface IQueryFacadeAssunto : IQueryFacade<Assunto>
    {
        Task<AssuntoViewModel> FirstAsync(int id, CancellationToken cancellationToken = default);
    }
}
