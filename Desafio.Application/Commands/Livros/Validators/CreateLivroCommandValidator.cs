using Desafio.Application.Commands.Livros.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Livros.Validators
{
    public class CreateLivroCommandValidator : AbstractValidator<CreateLivroCommand>
    {
        public CreateLivroCommandValidator()
        {
            RuleFor(command => command)
                .SetValidator(new LivroCommandValidator());
        }
    }
}
