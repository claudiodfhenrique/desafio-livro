namespace Desafio.Domain.Entities
{
    public class LivroAutor : Entity
    {
        public int AutorCodAu { get; init; }
        public int LivroCod { get; init; }
        public Autor Autor { get; init; }
        public Livro Livro { get; init; }
    }
}
