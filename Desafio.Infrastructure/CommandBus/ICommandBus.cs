namespace Desafio.Infrastructure.CommandBus
{
    public interface ICommandBus
    {
        Task<CommandResult> Send(ICommand command, CancellationToken cancellationToken = default);
    }
}
