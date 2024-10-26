using Desafio.Domain.Config;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infrastructure.Config
{
    public class LivroAssuntoConfig : EntityConfig<LivroAssunto>
    {
        public override void Configure(EntityTypeBuilder<LivroAssunto> builder)
        {
            builder.HasKey(x => new { x.LivroCod, x.AssuntoCodAss });

            base.Configure(builder);
        }

    }
}
