using Desafio.Application.Commands.Assuntos.Commands;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Application.Commands.Assuntos.CommandsHandlers
{
    public class DeleteAssuntoCommandHandler : ICommandHandler<DeleteAssuntoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssuntoRepository _repository;

        public DeleteAssuntoCommandHandler(
            IUnitOfWork unitOfWork,
            IAssuntoRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = await _repository.FindOneAsync(f => f.CodAss == request.Id, cancellationToken);
            if (assunto is null)
                return CommandResult.CompletedError(request.Id);
            //caso esteje vinculado com o livro nao deixar excluir
            //incremente o middleware de validation result....
            await _repository.DeleteAsync(assunto, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess();
        }
    }
}
