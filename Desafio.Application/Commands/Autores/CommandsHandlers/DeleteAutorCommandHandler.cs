using Desafio.Application.Commands.Assuntos.Commands;
using Desafio.Application.Commands.Autores.Commands;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Commands.Autores.CommandsHandlers
{
    public class DeleteAutorCommandHandler : ICommandHandler<DeleteAutorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutorRepository _repository;

        public DeleteAutorCommandHandler(
            IUnitOfWork unitOfWork,
            IAutorRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
        {
            var assunto = await _repository.FindOneAsync(f => f.CodAu == request.Id, cancellationToken);
            if (assunto is null)
                return CommandResult.CompletedError(request.Id);

            await _repository.DeleteAsync(assunto, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(request.Id);
        }
    }
}
