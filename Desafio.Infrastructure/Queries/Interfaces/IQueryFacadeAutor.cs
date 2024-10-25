using Desafio.Domain.Entities;
using Desafio.Infrastructure.Queries.ViewModel;

namespace Desafio.Infrastructure.Queries.Interfaces
{
    public interface IQueryFacadeAutor : IQueryFacade<Autor>
    {
        Task<AutorViewModel> FirstAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<AutorViewModel>> ListAsync(CancellationToken cancellationToken = default);
    }
}
