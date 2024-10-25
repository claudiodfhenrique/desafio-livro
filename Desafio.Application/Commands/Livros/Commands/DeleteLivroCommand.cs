using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Livros.Commands
{
    public class DeleteLivroCommand : ICommand
    {
        public int Id { get; set; }

        public DeleteLivroCommand(int id)
        {
            Id = id;
        }
    }
}
