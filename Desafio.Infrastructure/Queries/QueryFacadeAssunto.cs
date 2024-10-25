using AutoMapper;
using Desafio.Application.Queries.Assuntos.ViewModel;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Queries.Interfaces;

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
            var queryResult = await base.FirstAsync(f => f.CodAss == id, cancellationToken);
            if (queryResult is not null)
                return _mapper.Map<AssuntoViewModel>(queryResult);
            
            return new AssuntoViewModel();
        }
    }
}
