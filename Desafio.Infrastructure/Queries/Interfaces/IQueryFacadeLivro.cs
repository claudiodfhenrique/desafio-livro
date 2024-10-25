using Desafio.Domain.Entities;
using Desafio.Infrastructure.Queries.ViewModel;

namespace Desafio.Infrastructure.Queries.Interfaces
{
    public interface IQueryFacadeLivro :  IQueryFacade<Livro>
    {
        Task<LivroViewModel> FirstAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<LivroViewModel>> ListAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<VwLivrosPorAutorViewModel>> ReportAsync(CancellationToken  cancellationToken = default);
    }
}
