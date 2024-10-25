namespace Desafio.Domain.Entities
{
    public class Assunto : Entity
    {
        public int CodAss { get; set; }
        public string Descricao { get; set; }
        public List<Livro> LivroAssunto { get; set; } = new List<Livro>();    
    }
}
