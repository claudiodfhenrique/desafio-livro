using System.Linq.Expressions;

namespace Desafio.Infrastructure.Repository.Interfaces
{
    public interface IRepository<TEntidade>
    {
        Task<TEntidade> DeleteAsync(TEntidade entity, CancellationToken cancellationToken = default);
        
        Task<TEntidade> CreateAsync(TEntidade entity, CancellationToken cancellationToken = default);
        
        Task<TEntidade> FindOneAsync(
            Expression<Func<TEntidade, bool>> filter, 
            CancellationToken cancellationToken = default
        );

        Task<TEntidade> UpdateAsync(TEntidade entidade, CancellationToken cancellationToken = default);
    }
}
