using Desafio.Application.Commands.Livros.Commands;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Application.Commands.Livros.CommandsHandles
{
    public class DeleteLivroCommandHandler : ICommandHandler<DeleteLivroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILivroRepository _repository;

        public DeleteLivroCommandHandler(
            IUnitOfWork unitOfWork, 
            ILivroRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
