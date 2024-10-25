using Desafio.Domain.Entities;
using Desafio.Infrastructure.Config;
using Desafio.Infrastructure.Context.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AssuntoConfig());
            builder.ApplyConfiguration(new AutorConfig());
        }


        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }
    }
}
