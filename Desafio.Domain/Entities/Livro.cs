namespace Desafio.Domain.Entities
{
    public class Livro : Entity
    {
        public int Cod { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public short AnoPublicacao { get; set; }
        public List<Assunto> LivroAssunto { get; set; } = new List<Assunto>();        
        //public List<Autor> Autores { get; set; } = new List<Autor>();
    }
}
