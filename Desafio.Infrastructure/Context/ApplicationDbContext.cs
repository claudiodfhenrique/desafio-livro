using Desafio.Domain.Entities;
using Desafio.Domain.Views;
using Desafio.Infrastructure.Config;
using Desafio.Infrastructure.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Desafio.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
        public DbSet<LivroAssunto> LivroAssunto { get; set; }
        public DbSet<VwLivrosPorAutor> VWBoletosVencimentoAnual { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AssuntoConfig());
            builder.ApplyConfiguration(new AutorConfig());
            builder.ApplyConfiguration(new LivroConfig());
            builder.ApplyConfiguration(new LivroAutorConfig());
            builder.ApplyConfiguration(new LivroAssuntoConfig());

            builder.Entity<VwLivrosPorAutor>()
                .ToView("VW_LIVROS_POR_AUTOR")
                .HasKey(t => t.Id);
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
