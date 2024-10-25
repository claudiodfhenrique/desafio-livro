using Desafio.Application.Commands.Autores.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Autores.Validators
{
    public class UpdateAutorCommandValidator : AbstractValidator<CreateAutorCommand>
    {
        public UpdateAutorCommandValidator()
        {
            RuleFor(command => command)
                .SetValidator(new AutorCommandValidator());
        }
    }
}
