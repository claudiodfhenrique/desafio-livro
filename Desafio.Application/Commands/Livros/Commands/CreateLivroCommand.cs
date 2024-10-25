using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Livros.Commands
{
    public class CreateLivroCommand : LivroCommand, ICommand
    {
        public IEnumerable<int> LivroAutores { get; init; }
        public IEnumerable<int> LivroAssuntos {  get; init; }
    }
}
