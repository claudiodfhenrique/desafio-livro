using Desafio.Application.Commands.Autores.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Autores.Validators
{
    public class AutorCommandValidator : AbstractValidator<AutorCommand>
    {
        public AutorCommandValidator()
        {
            RuleFor(command => command.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);
        }
    }
}
