using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Dominio.Modelos;
using Application.Input;

namespace App.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        private IClienteAppService _appService { get; }

        public ClienteController(IClienteAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int paginaAtual, int totalPagina)
        {
            return Ok(await _appService.ListarTodos(paginaAtual, totalPagina));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _appService.Obter(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente obj)
        {
            await _appService.Adicionar(obj.Nome);
            return StatusCode(201);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ClienteInput obj)
        {
            await _appService.Atualizar(id, obj.Nome);
            return Accepted(obj);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appService.Excluir(id);
            return Ok();
        }
    }
}