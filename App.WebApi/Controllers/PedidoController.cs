using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Input;

namespace App.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Pedido")]
    public class PedidoController : Controller
    {
        private IPedidoAppService _appService { get; }

        public PedidoController(IPedidoAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _appService.ObterPedido(id));
        }

        [HttpGet("Cliente/{id}")]
        public IActionResult GetPedidoCliente(int id)
        {
            return Ok(_appService.ObterPedidosPorCliente(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoInput obj)
        {
            await _appService.AdicionarPedido(obj.IdCliente, obj.Itens);
            return StatusCode(201);
        }
    }
}