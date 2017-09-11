using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace App.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cardapio")]
    public class CardapioController : Controller
    {
        private ICardapioAppService _appService { get; }

        public CardapioController(ICardapioAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int idLanche, int idIngrediente)
        {
            return Ok(_appService.Obter(idLanche, idIngrediente));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int idLanche)
        {
            return Ok(_appService.ObterCardapioPorLanche(idLanche));
        }
    }
}
