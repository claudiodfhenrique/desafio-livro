using Desafio.Application.Commands.Assuntos.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Assuntos.Validators
{
    public class UpdateAssuntoCommandValidator : AbstractValidator<UpdateAssuntoCommand>
    {
        public UpdateAssuntoCommandValidator()
        {
            RuleFor(command => command)
                .SetValidator(new AssuntoCommandValidator());
        }
    }
}
