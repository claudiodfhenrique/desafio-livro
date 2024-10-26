﻿using Desafio.Domain.Entities;

namespace Desafio.Infrastructure.Repository.Interfaces
{
    public interface ILivroAutorRepository : IRepository<LivroAutor>
    {
        Task<IEnumerable<LivroAutor>> ListByAsync(
            int livroCod,
            CancellationToken cancellationToken = default
        );
    }
}
