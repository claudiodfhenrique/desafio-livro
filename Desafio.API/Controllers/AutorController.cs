using Desafio.Application.Commands.Autores.Commands;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Queries.Interfaces;
using Desafio.Infrastructure.Queries.ViewModel;
using Desafio.Infrastructure.Util;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Desafio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryFacadeAutor _queries;

        public AutorController(
            ICommandBus commandBus,
            IQueryFacade<Autor> queries)
        {
            _commandBus = commandBus;
            _queries = (IQueryFacadeAutor)queries;
        }

        /// <summary>
        /// Recuperar todos os autores de livro
        /// </summary>        
        /// <response code="200">Registro recuperado com sucesso.</response>        
        /// <response code="404">Dados recupetado com sucesso.</response>
        [HttpGet("todos")]
        [ProducesResponseType(typeof(IEnumerable<AutorViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> All()
        {
            var result = await _queries.ListAsync(new CancellationToken());
            return Ok(result);
        }

        /// <summary>
        /// Excluir autor do livro
        /// </summary>
        /// <param name="id">Identificador do assunto</param>
        /// <response code="200">Exclusão realizada com sucesso.</response>        
        /// <response code="400">Dados informados estão incorretos.</response>
        /// <response code="500">Oops! Não foi possível realizar a operação.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _commandBus.Send(new DeleteAutorCommand(id), new CancellationToken());
            if (!result.Success)
                return BadRequest();

            return Ok(result.Id);
        }

        /// <summary>
        /// Recuperar o autor do livro
        /// </summary>
        /// <param name="id">Identificador do autor</param>
        /// <response code="200">Registro recuperado com sucesso.</response>        
        /// <response code="404">Dados recupetado com sucesso.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AutorViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _queries.FirstAsync(id, new CancellationToken());
            return Ok(result);
        }

        /// <summary>
        /// Cadastrar auto do livro
        /// </summary>
        /// <param name="command">Dados de cadastro</param>
        /// <response code="200">Cadastro realizado com sucesso.</response>        
        /// <response code="400">Dados informados estão incorretos.</response>
        /// <response code="500">Oops! Não foi possível realizar a operação.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody, Required] CreateAutorCommand command)
        {
            var result = await _commandBus.Send(command, new CancellationToken());
            if (!result.Success)
                return BadRequest();

            return Created(nameof(Post), result.Id);
        }

        /// <summary>
        /// Atualizar autor do livro
        /// </summary>
        /// <param name="command">Dados de atualização</param>
        /// <response code="200">Atualização realizada com sucesso.</response>        
        /// <response code="400">Dados informados estão incorretos.</response>
        /// <response code="500">Oops! Não foi possível realizar a operação.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody, Required] UpdateAutorCommand command)
        {
            var result = await _commandBus.Send(command, new CancellationToken());
            if (!result.Success)
                return BadRequest();

            return Ok(result.Id);
        }
    }
}
