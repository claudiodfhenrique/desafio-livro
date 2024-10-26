namespace Desafio.Domain.Entities
{
    public class Livro : Entity
    {
        public int Cod { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public virtual ICollection<LivroAssunto> LivroAssunto { get; set; } = new List<LivroAssunto>();        
        public virtual ICollection<LivroAutor> LivroAutor { get; set; } = new List<LivroAutor>();
    }
}
