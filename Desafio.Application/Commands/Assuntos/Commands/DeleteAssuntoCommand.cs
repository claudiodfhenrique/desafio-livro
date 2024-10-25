using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Assuntos.Commands
{
    public class DeleteAssuntoCommand : ICommand
    {
        public int Id { get; init; }

        public DeleteAssuntoCommand(int id)
        {
            Id = id;
        }
    }
}
