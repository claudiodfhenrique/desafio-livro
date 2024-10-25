using AutoMapper;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Desafio.Infrastructure.Queries
{
    public class QueryFacade<TDocument> : IQueryFacade<TDocument> where TDocument : Entity
    {
        protected readonly IMapper _mapper;
        protected readonly ApplicationDbContext _context;

        public QueryFacade(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TDocument> FirstAsync(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TDocument>().FirstOrDefaultAsync(filter, cancellationToken);
        }
    }
}
