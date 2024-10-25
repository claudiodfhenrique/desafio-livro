namespace Desafio.Domain.Views
{
    public class VwLivrosPorAutor : IView
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
	    public string Editora { get; set; }
	    public int Edicao { get;set; }
	    public string Assunto { get; set; }
        public string AutorNome { get; set; }
    }
}
