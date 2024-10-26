using Desafio.Application.Commands.Livros.Commands;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Application.Commands.Livros.CommandsHandles
{
    public class UpdateLivroCommandHandler : ICommandHandler<UpdateLivroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILivroRepository _repository;

        public UpdateLivroCommandHandler(
            IUnitOfWork unitOfWork, 
            ILivroRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _repository.FirstAsync(f => f.Cod == request.Cod, cancellationToken);
            if (livro is null)
                return CommandResult.CompletedError(request.Cod);

            livro.Titulo = request.Titulo;
            livro.Editora = request.Editora;
            livro.Edicao = request.Edicao;
            livro.AnoPublicacao = request.AnoPublicacao;

            await _repository.UpdateAsync(livro, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(livro.Cod);
        }
    }
}
