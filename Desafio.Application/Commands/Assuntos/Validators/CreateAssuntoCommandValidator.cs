using Desafio.Application.Commands.Assuntos.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Assuntos.Validators
{
    public class CreateAssuntoCommandValidator : AbstractValidator<CreateAssuntoCommand>
    {
        public CreateAssuntoCommandValidator()
        {
            RuleFor(command => command)
                .SetValidator(new AssuntoCommandValidator());
        }
    }
}
