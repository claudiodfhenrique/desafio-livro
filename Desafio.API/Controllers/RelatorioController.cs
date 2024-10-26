using Desafio.Domain.Entities;
using Desafio.Infrastructure.Queries.Interfaces;
using Desafio.Infrastructure.Queries.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IQueryFacadeLivro _queries;

        public RelatorioController(IQueryFacade<Livro> queries)
        {
            _queries = (IQueryFacadeLivro)queries;
        }

        /// <summary>
        /// Recuperar todos livros agrupados por autor
        /// </summary>        
        /// <response code="200">Registro recuperado com sucesso.</response>        
        /// <response code="404">Dados recupetado com sucesso.</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<VwLivrosPorAutorViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> All()
        {
            var result = await _queries.ReportAsync(new CancellationToken());
            return Ok(result);
        }
    }
}
