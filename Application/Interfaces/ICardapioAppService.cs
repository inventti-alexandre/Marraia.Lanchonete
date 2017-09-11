using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ICardapioAppService
    {
        IList<Cardapio> ObterCardapioPorLanche(int idLanche);
        Cardapio Obter(int idLanche, int idIngrediente);
    }
}
