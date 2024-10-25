using Desafio.Application.Commands.Assuntos.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Assuntos.Validators
{
    public sealed class AssuntoCommandValidator : AbstractValidator<AssuntoCommand>
    {
        public AssuntoCommandValidator()
        {
            RuleFor(command => command.Descricao)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(80);
        }
    }
}
