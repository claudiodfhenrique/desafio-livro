using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Infrastructure.Repository
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public LivroRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
