using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Assuntos.Commands
{
    public class AssuntoCommand : ICommand
    {
        public string Descricao { get; init; } 
    }
}
