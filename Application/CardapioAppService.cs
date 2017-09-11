using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Modelos;
using Dominio.Interfaces;

namespace Application
{
    public class CardapioAppService : ICardapioAppService
    {
        private ICardapioRepositorio _repo { get; }
        public CardapioAppService(ICardapioRepositorio repo)
        {
            _repo = repo;
        }

        public Cardapio Obter(int idLanche, int idIngrediente)
        {
            return _repo.Obter(idLanche, idIngrediente);
        }

        public IList<Cardapio> ObterCardapioPorLanche(int idLanche)
        {
           return _repo.ObterCardapioPorLanche(idLanche);
        }
    }
}
