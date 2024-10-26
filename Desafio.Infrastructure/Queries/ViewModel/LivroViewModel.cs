namespace Desafio.Infrastructure.Queries.ViewModel
{
    public readonly struct LivroViewModel
    {
        public int Cod { get; init; }
        public string Titulo { get; init; }
        public string Editora { get; init; }
        public int Edicao { get; init; }
        public int AnoPublicacao { get; init; }
        public IEnumerable<LivroAssuntoViewModel> LivroAssunto { get; init; }
        public IEnumerable<LivroAutorViewModel> LivroAutor { get; init; }
    }
}
