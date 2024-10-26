﻿using System.Linq.Expressions;

namespace Desafio.Infrastructure.Queries.Interfaces
{
    public interface IQueryFacade<TDocument> : IQueryFacadeOptions
    {
        Task<TDocument> FirstAsync(
            Expression<Func<TDocument, bool>> filter,
            CancellationToken cancellationToken = default
        );

        Task<IEnumerable<TDocument>> ListAsync(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken = default);
    }
}
