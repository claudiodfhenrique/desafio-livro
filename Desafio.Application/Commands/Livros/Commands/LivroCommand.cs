using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Livros.Commands
{
    public class LivroCommand : ICommand
    {
        public string Titulo { get; init; }
        public string Editora { get; init; }
        public int Edicao { get; init; }
        public int AnoPublicacao { get; init; }
    }
}
