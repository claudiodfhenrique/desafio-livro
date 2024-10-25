using Desafio.Application.Commands.Autores.Commands;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Application.Commands.Autores.CommandsHandlers
{
    public class UpdateAutorCommandHandler : ICommandHandler<UpdateAutorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutorRepository _repository;

        public UpdateAutorCommandHandler(
            IUnitOfWork unitOfWork,
            IAutorRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            var assunto = await _repository.FindOneAsync(f => f.CodAu == request.Id, cancellationToken);
            if (assunto is null)
                return CommandResult.CompletedError(request.Id);

            assunto.Nome = request.Nome;
            await _repository.UpdateAsync(assunto, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(assunto.CodAu);
        }
    }
}
