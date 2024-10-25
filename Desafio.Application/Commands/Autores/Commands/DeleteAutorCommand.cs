using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Autores.Commands
{
    public class DeleteAutorCommand : ICommand
    {
        public int Id { get; init; }

        public DeleteAutorCommand(int id)
        {
            Id = id;
        }
    }
}
