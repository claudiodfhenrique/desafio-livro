using MediatR;

namespace Desafio.Infrastructure.CommandBus
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, CommandResult> where TCommand : ICommand
    {
    }
}
