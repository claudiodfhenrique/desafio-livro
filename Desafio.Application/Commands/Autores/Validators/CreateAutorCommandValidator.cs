using Desafio.Application.Commands.Autores.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Autores.Validators
{
    public class CreateAutorCommandValidator : AbstractValidator<CreateAutorCommand>
    {
        public CreateAutorCommandValidator()
        {
            RuleFor(command => command)
                .SetValidator(new AutorCommandValidator());
        }
    }
}
