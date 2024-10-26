namespace Desafio.Domain.Entities
{
    public class LivroAssunto : Entity
    {
        public int LivroCod { get; init; }
        public int AssuntoCodAss { get; init; }
        public Assunto Assunto { get; init; }
    }
}
