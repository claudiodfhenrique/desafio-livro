using Desafio.Domain.Entities;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Desafio.Infrastructure.Repository
{
    public class RepositoryBase<TEntidade> : IRepository<TEntidade> where TEntidade : Entity, new()
    {
        protected readonly ApplicationDbContext Context;

        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public Task<TEntidade> DeleteAsync(TEntidade entity, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntidade>().Remove(entity);
            return Task.FromResult(entity);
        }

        public async Task<TEntidade> CreateAsync(TEntidade entity, CancellationToken cancellationToken = default)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.Set<TEntidade>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<TEntidade> FindOneAsync(
            Expression<Func<TEntidade, bool>> filter, 
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntidade> query = Context.Set<TEntidade>();
            return await query.SingleOrDefaultAsync(filter, cancellationToken);
        }        

        public Task<TEntidade> UpdateAsync(TEntidade entidade, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntidade>().Update(entidade);
            return Task.FromResult(entidade);
        }
    }
}
