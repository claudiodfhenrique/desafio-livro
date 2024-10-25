using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Infrastructure.Repository
{
    public class AssuntoRepository : RepositoryBase<Assunto>, IAssuntoRepository
    {
        public AssuntoRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
