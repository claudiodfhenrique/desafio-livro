using System.Linq.Expressions;

namespace Desafio.Infrastructure.Queries.Interfaces
{
    public interface IQueryFacade<TDocument>
    {
        Task<TDocument> FirstAsync(
            Expression<Func<TDocument, bool>> filter,
            CancellationToken cancellationToken = default
        );
    }
}
