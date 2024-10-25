namespace Desafio.Domain.Entities
{
    public class Autor : Entity
    {
        public int CodAu { get; set; }
        public string Nome { get; set; }
        //public List<Livro> Livros { get; set; } = new List<Livro>();
    }
}
