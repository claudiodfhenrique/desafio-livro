using Desafio.Application.Commands.Assuntos.Commands;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Application.Commands.Assuntos.CommandsHandlers
{
    public class UpdateAssuntoCommandHandler : ICommandHandler<UpdateAssuntoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssuntoRepository _repository;

        public UpdateAssuntoCommandHandler(
            IUnitOfWork unitOfWork,
            IAssuntoRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(UpdateAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = await _repository.FirstAsync(f => f.CodAss == request.CodAss, cancellationToken);
            if (assunto is null)
                return CommandResult.CompletedError(request.CodAss);

            assunto.Descricao = request.Descricao;
            await _repository.UpdateAsync(assunto, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(request.CodAss);
        }
    }
}
