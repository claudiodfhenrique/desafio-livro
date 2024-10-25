using AutoMapper;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Queries.Interfaces;
using Desafio.Infrastructure.Queries.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infrastructure.Queries
{
    public class QueryFacadeLivro : QueryFacade<Livro>, IQueryFacadeLivro
    {
        public QueryFacadeLivro(
            IMapper mapper,
            ApplicationDbContext context) : base(context, mapper)
        {
        }

        public async Task<LivroViewModel> FirstAsync(int id, CancellationToken cancellationToken = default)
        {
            var queryResult = await FirstAsync(f => f.Cod == id, cancellationToken);
            if (queryResult is not null)
                return _mapper.Map<LivroViewModel>(queryResult);

            return new LivroViewModel();
        }

        public async Task<IEnumerable<LivroViewModel>> ListAsync(CancellationToken cancellationToken = default)
        {
            var queryResult = await ListAsync(_ => true, cancellationToken);
            return _mapper.Map<IList<LivroViewModel>>(queryResult);
        }

        public async Task<IEnumerable<VwLivrosPorAutorViewModel>> ReportAsync(CancellationToken cancellationToken = default)
        {
            var queryResult = await (from r in _context.VWBoletosVencimentoAnual select r).ToListAsync(cancellationToken);
            return _mapper.Map<IList<VwLivrosPorAutorViewModel>>(queryResult);
        }
    }
}
