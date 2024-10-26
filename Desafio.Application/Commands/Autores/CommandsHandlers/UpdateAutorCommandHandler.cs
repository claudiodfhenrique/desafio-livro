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
            var assunto = await _repository.FirstAsync(f => f.CodAu == request.CodAu, cancellationToken);
            if (assunto is null)
                return CommandResult.CompletedError(request.CodAu);

            assunto.Nome = request.Nome;
            await _repository.UpdateAsync(assunto, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(assunto.CodAu);
        }
    }
}
