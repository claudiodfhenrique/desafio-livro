namespace Desafio.Infrastructure.Queries.ViewModel
{
    public readonly struct VwLivrosPorAutorViewModel
    {
        public int Id { get; init; }
        public string Titulo { get; init; }
        public string Editora { get; init; }
        public int Edicao { get; init; }
        public string Assunto { get; init; }
        public string AutorNome { get; init; }
    }
}
