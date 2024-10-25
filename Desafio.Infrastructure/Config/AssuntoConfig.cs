using Desafio.Domain.Config;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infrastructure.Config
{
    public class AssuntoConfig : EntityConfig<Assunto>
    {
        public override void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder.HasKey(x => x.CodAss);
            builder.Property(x => x.Descricao)
                .HasColumnType("VARCHAR(80)")
                .IsRequired()
                .HasMaxLength(80);

            base.Configure(builder);
        }
    }
}
