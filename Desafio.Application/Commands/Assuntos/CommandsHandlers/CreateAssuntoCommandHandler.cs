using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;
using Desafio.Domain.Entities;
using Desafio.Application.Commands.Assuntos.Commands;

namespace Desafio.Application.Commands.Assuntos.CommandsHandlers
{
    public class CreateAssuntoCommandHandler : ICommandHandler<CreateAssuntoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssuntoRepository _repository;

        public CreateAssuntoCommandHandler(
            IUnitOfWork unitOfWork,
            IAssuntoRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(CreateAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = new Assunto
            {
                Descricao = request.Descricao
            };

            await _repository.CreateAsync(assunto, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess();
        }
    }
}
