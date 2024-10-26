using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Infrastructure.Repository
{
    public class LivroAssuntoRepository : RepositoryBase<LivroAssunto>, ILivroAssuntoRepository
    {
        public LivroAssuntoRepository(ApplicationDbContext Context) : base(Context)
        {
        }

        public async Task<IEnumerable<LivroAssunto>> ListByAsync(
            int livroCod,
            CancellationToken cancellationToken = default
        )
        {
            return await ListAsync(f => f.LivroCod == livroCod, cancellationToken);
        }
    }
}
