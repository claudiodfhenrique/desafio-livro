using Desafio.Application.Commands.Livros.Commands;
using FluentValidation;

namespace Desafio.Application.Commands.Livros.Validators
{
    public class UpdateLivroCommandValidator : AbstractValidator<UpdateLivroCommand>
    {
        public UpdateLivroCommandValidator()
        {
            RuleFor(command => command)
                .SetValidator(new LivroCommandValidator());
        }
    }
}
