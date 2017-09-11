using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Input
{
    public class PedidoItemInput
    {
        public int IdLanche { get; set; }
        public List<CardapioItemInput> Ingredientes { get; set; }
    }

    public class CardapioItemInput
    {
        public int IdIngrediente { get; set; }
        public int Quantidade { get; set; }
    }

    [Serializable]
    public class PedidoInput
    {
        public int IdCliente { get; set; }
        public List<PedidoItemInput> Itens { get; set; }
    }
}
