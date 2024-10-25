using Desafio.Domain.Config;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infrastructure.Config
{
    public class AutorConfig : EntityConfig<Autor>
    {
        public override void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x => x.CodAu);
            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired()
                .HasMaxLength(100);           

            base.Configure(builder);
        }
    }
}
