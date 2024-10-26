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
        private readonly ILivroAutorRepository _livroAutorRepository;
        private readonly ILivroAssuntoRepository _livroAssuntoRepository;

        public CreateLivroCommandHandler(
            IUnitOfWork unitOfWork,
            ILivroRepository repository,
            ILivroAutorRepository livroAutorRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _livroAutorRepository = livroAutorRepository;
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

            await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                await _repository.CreateAsync(livro, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                await CreateAutoresAsync(livro, request, cancellationToken);
                await CreateAssuntosAsync(livro, request, cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return CommandResult.CompletedSuccess(livro.Cod);
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        private async Task CreateAutoresAsync(
            Livro livro,
            CreateLivroCommand request, 
            CancellationToken cancellationToken)
        {
            if (request.LivroAutores is not null && request.LivroAutores.Any())
            {
                foreach (var autorId in request.LivroAutores)
                    await _livroAutorRepository.CreateAsync(new LivroAutor
                    {
                        LivroCod = livro.Cod,
                        AutorCodAu = autorId
                    }, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);
            }
        }

        private async Task CreateAssuntosAsync(
            Livro livro,
            CreateLivroCommand request,
            CancellationToken cancellationToken)
        {
            if (request.LivroAssuntos is not null && request.LivroAssuntos.Any())
            {
                foreach (var assuntoId in request.LivroAssuntos)
                    await _livroAssuntoRepository.CreateAsync(new LivroAssunto
                    {
                        LivroCod = livro.Cod,
                        AssuntoCodAss = assuntoId
                    }, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);
            }
        }
    }
}
