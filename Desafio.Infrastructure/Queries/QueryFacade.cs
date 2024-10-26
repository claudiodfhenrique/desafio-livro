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
        private List<string> _navigations;
        protected readonly IMapper _mapper;
        protected readonly ApplicationDbContext _context;

        public QueryFacade(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _navigations = new();
        }

        private IQueryable<TDocument> IncludeNavigations(IQueryable<TDocument> query)
        {
            foreach (var navigation in _navigations)
                query = query.Include(navigation);
            return query;
        }

        public virtual void InsertNavigations(params string[] navigations)
        {
            _navigations.AddRange(from navigation in navigations select navigation);
        }

        public async Task<TDocument> FirstAsync(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await IncludeNavigations(_context.Set<TDocument>()).FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<IEnumerable<TDocument>> ListAsync(
            Expression<Func<TDocument, bool>> filter,
            CancellationToken cancellationToken = default)
        {
            return await IncludeNavigations(_context.Set<TDocument>()).Where(filter).ToListAsync(cancellationToken);
        }
    }
}
