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
            var assunto = await _assuntoRepository.FirstAsync(f => f.CodAss == 2, cancellationToken);
            var livro = new Livro
            {
                Titulo = "Título",
                Editora = "Editora",
                Edicao = 1,
                AnoPublicacao = 2,
                LivroAssunto = new List<Assunto>
                {
                    assunto
                },
                //LivroAutor = new List<LivroAutor>
                //{
                //    new() { AutorCodAu = 2 }
                //}
            };

            await _repository.CreateAsync(livro, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return CommandResult.CompletedSuccess(livro.Cod);
        }
    }
}
