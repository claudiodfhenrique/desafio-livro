using Desafio.Application.Commands.Livros.Commands;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Repository.Interfaces;

namespace Desafio.Application.Commands.Livros.CommandsHandles
{
    public class UpdateLivroCommandHandler : ICommandHandler<UpdateLivroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILivroRepository _repository;
        private readonly ILivroAutorRepository _livroAutorRepository;
        private readonly ILivroAssuntoRepository _livroAssuntoRepository;

        public UpdateLivroCommandHandler(
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

        public async Task<CommandResult> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _repository.FirstAsync(f => f.Cod == request.Cod, cancellationToken);
            if (livro is null)
                return CommandResult.CompletedError(request.Cod);

            await UpdateAutoresAsync(request, cancellationToken);
            await UpdateAssuntosAsync(request, cancellationToken);
            await UpdateLivroAsync(request, livro, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(livro.Cod);
        }

        private async Task UpdateLivroAsync(
            UpdateLivroCommand request, 
            Livro livro,
            CancellationToken cancellationToken)
        {
            livro.Titulo = request.Titulo;
            livro.Editora = request.Editora;
            livro.Edicao = request.Edicao;
            livro.AnoPublicacao = request.AnoPublicacao;

            await _repository.UpdateAsync(livro, cancellationToken);
        }

        private async Task UpdateAutoresAsync(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var autores = await _livroAutorRepository.ListByAsync(request.Cod, cancellationToken);
            foreach (var autor in autores)
            {
                if (!request.LivroAutores.Contains(autor.AutorCodAu))
                    await _livroAutorRepository.DeleteAsync(autor, cancellationToken);
            }

            foreach (var autorId in request.LivroAutores)
            {
                if (!autores.Any(f => f.AutorCodAu == autorId))
                    await _livroAutorRepository.CreateAsync(new LivroAutor 
                    {
                        LivroCod = request.Cod,
                        AutorCodAu = autorId,
                    }, cancellationToken);
            }
        }

        private async Task UpdateAssuntosAsync(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var assuntos = await _livroAssuntoRepository.ListByAsync(request.Cod, cancellationToken);
            foreach (var assunto in assuntos)
            {
                if (!request.LivroAssuntos.Contains(assunto.AssuntoCodAss))
                    await _livroAssuntoRepository.DeleteAsync(assunto, cancellationToken);
            }

            foreach (var assuntoId in request.LivroAssuntos)
            {
                if (!assuntos.Any(f => f.AssuntoCodAss == assuntoId))
                    await _livroAssuntoRepository.CreateAsync(new LivroAssunto
                    {
                        LivroCod = request.Cod,
                        AssuntoCodAss = assuntoId,
                    }, cancellationToken);
            }
        }
    }
}
