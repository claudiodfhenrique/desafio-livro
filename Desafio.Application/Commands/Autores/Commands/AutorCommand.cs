using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Autores.Commands
{
    public class AutorCommand : ICommand
    {
        public string Nome {  get; init; }
    }
}
