using MediatR;

namespace Desafio.Infrastructure.CommandBus
{
    public interface ICommand : IRequest<CommandResult>
    {
    }
}
