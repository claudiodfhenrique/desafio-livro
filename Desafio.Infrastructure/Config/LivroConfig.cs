using Desafio.Domain.Config;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infrastructure.Config
{
    public class LivroConfig : EntityConfig<Livro>
    {
        public override void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Cod);
            builder.Property(x => x.Titulo)
                .HasColumnType("VARCHAR(100)")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Editora)
                .HasColumnType("VARCHAR(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.LivroAutor);            

            base.Configure(builder);
        }
    }
}
