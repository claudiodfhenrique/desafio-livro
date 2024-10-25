using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Infrastructure.Repository
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
