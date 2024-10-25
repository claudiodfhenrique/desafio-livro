using Desafio.Infrastructure.CommandBus;
using Desafio.Application.Commands.Assuntos.Commands;
using Desafio.Application.Queries.Assuntos.ViewModel;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.Queries.Interfaces;
using Desafio.Infrastructure.Util;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Desafio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssuntoController : ControllerBase
    { 
        private readonly ICommandBus _commandBus; 
        private readonly IQueryFacadeAssunto _queries;

        public AssuntoController(
            ICommandBus commandBus, 
            IQueryFacade<Assunto> queries)
        {
            _commandBus = commandBus;
            _queries = (IQueryFacadeAssunto)queries;
        }

        /// <summary>
        /// Excluir assunto do livro
        /// </summary>
        /// <param name="id">Identificador do assunto</param>
        /// <response code="200">Exclus�o realizada com sucesso.</response>        
        /// <response code="400">Dados informados est�o incorretos.</response>
        /// <response code="500">Oops! N�o foi poss�vel realizar a opera��o.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _commandBus.Send(new DeleteAssuntoCommand(id), new CancellationToken());
            if (!result.Success)
                return BadRequest();

            return Ok(result.Id);
        }

        /// <summary>
        /// Recuperar o assunto do livro
        /// </summary>
        /// <param name="id">Identificador do assunto</param>
        /// <response code="200">Registro recuperado com sucesso.</response>        
        /// <response code="404">Dados recupetado com sucesso.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AssuntoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _queries.FirstAsync(id, new CancellationToken());
            return Ok(result);
        }

        /// <summary>
        /// Cadastrar assunto do livro
        /// </summary>
        /// <param name="command">Dados de cadastro</param>
        /// <response code="200">Cadastro realizado com sucesso.</response>        
        /// <response code="400">Dados informados est�o incorretos.</response>
        /// <response code="500">Oops! N�o foi poss�vel realizar a opera��o.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody, Required] CreateAssuntoCommand command)
        {
            var result = await _commandBus.Send(command, new CancellationToken());
            if (!result.Success)
                return BadRequest();

            return Created(nameof(Post), result.Id);
        }

        /// <summary>
        /// Atualizar assunto do livro
        /// </summary>
        /// <param name="command">Dados de atualiza��o</param>
        /// <response code="200">Atualiza��o realizada com sucesso.</response>        
        /// <response code="400">Dados informados est�o incorretos.</response>
        /// <response code="500">Oops! N�o foi poss�vel realizar a opera��o.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody, Required] UpdateAssuntoCommand command)
        {
            var result = await _commandBus.Send(command, new CancellationToken());
            if (!result.Success)
                return BadRequest();

            return Ok(result.Id);
        }
    }
}
