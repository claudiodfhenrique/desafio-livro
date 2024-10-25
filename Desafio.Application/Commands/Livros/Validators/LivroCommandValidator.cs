using Desafio.Application.Commands.Livros.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Livros.Validators
{
    public class LivroCommandValidator : AbstractValidator<LivroCommand>
    {
        public LivroCommandValidator()
        {
            RuleFor(command => command.Titulo)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);

            RuleFor(command => command.Editora)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);

            RuleFor(command => command.Edicao)
                .GreaterThan(0);

            RuleFor(command => command.AnoPublicacao)
                .GreaterThan(1900);
        }
    }
}
