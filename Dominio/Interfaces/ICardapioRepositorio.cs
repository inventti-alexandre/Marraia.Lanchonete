using Dominio.Modelos;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface ICardapioRepositorio 
    {
        IList<Cardapio> ObterCardapioPorLanche(int idLanche);
        Cardapio Obter(int idLanche, int idIngrediente);
    }
}
