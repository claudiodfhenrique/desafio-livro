using Desafio.Application.Commands.Livros.Commands;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Application.Commands.Livros.CommandsHandles
{
    public class CreateLivroCommandHandler : ICommandHandler<CreateLivroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILivroRepository _repository;
        private readonly IAssuntoRepository _assuntoRepository;

        public CreateLivroCommandHandler(
            IUnitOfWork unitOfWork,
            ILivroRepository repository,
            IAssuntoRepository assuntoRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _assuntoRepository = assuntoRepository;
        }

        public async Task<CommandResult> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro 
            {
                Titulo = request.Titulo,
                Editora = request.Editora,
                Edicao = request.Edicao,
                AnoPublicacao = request.AnoPublicacao
            };

            await _repository.CreateAsync(livro, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(livro.Cod);
        }
    }
}
