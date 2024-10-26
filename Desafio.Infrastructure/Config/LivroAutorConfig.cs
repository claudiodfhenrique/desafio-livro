using Desafio.Domain.Config;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infrastructure.Config
{
    public class LivroAutorConfig : EntityConfig<LivroAutor>
    {
        public override void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            builder.HasKey(x => new { x.AutorCodAu, x.LivroCod });           

            base.Configure(builder);
        }
    }
}
