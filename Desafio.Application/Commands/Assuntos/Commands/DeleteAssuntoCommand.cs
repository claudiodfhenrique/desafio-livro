using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Assuntos.Commands
{
    public class DeleteAssuntoCommand : ICommand
    {
        public long Id { get; init; }

        public DeleteAssuntoCommand(long id)
        {
            Id = id;
        }
    }
}
