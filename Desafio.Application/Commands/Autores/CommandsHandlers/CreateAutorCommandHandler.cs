using Desafio.Application.Commands.Autores.Commands;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Application.Commands.Autores.CommandsHandlers
{
    public class CreateAutorCommandHandler : ICommandHandler<CreateAutorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutorRepository _repository;

        public CreateAutorCommandHandler(
            IUnitOfWork unitOfWork,
            IAutorRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            var assunto = new Autor
            {
                Nome = request.Nome
            };

            await _repository.CreateAsync(assunto, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(assunto.CodAu);
        }
    }
}
