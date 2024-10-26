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
        private readonly ILivroAutorRepository _livroAutorRepository;
        private readonly ILivroAssuntoRepository _livroAssuntoRepository;

        public DeleteLivroCommandHandler(
            IUnitOfWork unitOfWork,
            ILivroRepository repository,
            ILivroAutorRepository livroAutorRepository,
            ILivroAssuntoRepository livroAssuntoRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _livroAutorRepository = livroAutorRepository;
            _livroAssuntoRepository = livroAssuntoRepository;
        }

        public async Task<CommandResult> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _repository.FirstAsync(f => f.Cod == request.Id, cancellationToken);
            if (livro is null)
                return CommandResult.CompletedError(request.Id);

            await DeleteAutoresAsync(request, cancellationToken);
            await DeleteAssuntossAsync(request, cancellationToken);
            await _repository.DeleteAsync(livro, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(request.Id);
        }

        private async Task DeleteAutoresAsync(DeleteLivroCommand request, CancellationToken cancellationToken)
        {
            var autores = await _livroAutorRepository.ListByAsync(request.Id, cancellationToken);
            foreach (var autor in autores)
                await _livroAutorRepository.DeleteAsync(autor, cancellationToken);
        }

        private async Task DeleteAssuntossAsync(DeleteLivroCommand request, CancellationToken cancellationToken)
        {
            var assuntos = await _livroAssuntoRepository.ListByAsync(request.Id, cancellationToken);
            foreach (var assunto in assuntos)
                await _livroAssuntoRepository.DeleteAsync(assunto, cancellationToken);
        }
    }
}
