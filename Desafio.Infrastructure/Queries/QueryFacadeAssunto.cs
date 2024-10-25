using AutoMapper;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Queries.Interfaces;
using Desafio.Infrastructure.Queries.ViewModel;

namespace Desafio.Infrastructure.Queries
{
    public class QueryFacadeAssunto : QueryFacade<Assunto>, IQueryFacadeAssunto
    {
        public QueryFacadeAssunto(
            IMapper mapper,
            ApplicationDbContext context) : base(context, mapper)
        {            
        }

        public async Task<AssuntoViewModel> FirstAsync(int id, CancellationToken cancellationToken = default)
        {
            var queryResult = await FirstAsync(f => f.CodAss == id, cancellationToken);
            if (queryResult is not null)
                return _mapper.Map<AssuntoViewModel>(queryResult);
            
            return new AssuntoViewModel();
        }

        public async Task<IEnumerable<AssuntoViewModel>> ListAsync(CancellationToken cancellationToken = default)
        {
            var queryResult = await ListAsync(_ => true, cancellationToken);
            return _mapper.Map<IList<AssuntoViewModel>>(queryResult);
        }
    }
}
