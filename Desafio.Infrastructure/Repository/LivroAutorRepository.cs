using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Infrastructure.Repository
{
    public class LivroAutorRepository : RepositoryBase<LivroAutor>, ILivroAutorRepository
    {
        public LivroAutorRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
