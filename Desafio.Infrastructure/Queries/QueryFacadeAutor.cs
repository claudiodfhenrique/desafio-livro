using AutoMapper;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Queries.Interfaces;
using Desafio.Infrastructure.Queries.ViewModel;

namespace Desafio.Infrastructure.Queries
{
    public class QueryFacadeAutor : QueryFacade<Autor>, IQueryFacadeAutor
    {
        public QueryFacadeAutor(
            IMapper mapper,
            ApplicationDbContext context) : base(context, mapper)
        {
        }

        public async Task<AutorViewModel> FirstAsync(int id, CancellationToken cancellationToken = default)
        {
            var queryResult = await base.FirstAsync(f => f.CodAu == id, cancellationToken);
            if (queryResult is not null)
                return _mapper.Map<AutorViewModel>(queryResult);

            return new AutorViewModel();
        }
    }
}
