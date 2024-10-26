﻿using Desafio.Infrastructure.CommandBus;

namespace Desafio.Application.Commands.Livros.Commands
{
    public class UpdateLivroCommand : LivroCommand, ICommand
    {
        public int Id { get; init; }
    }
}