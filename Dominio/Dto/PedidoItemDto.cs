using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Dto
{
    public class PedidoItemDto
    {
        public Lanche Lanche { get; private set; }
        public Ingrediente Ingrediente { get; private set; }
        public int Quantidade { get; private set; }

        public PedidoItemDto(Lanche lanche, Ingrediente ingrediente, int quantidade)
        {
            Lanche = lanche;
            Ingrediente = ingrediente;
            Quantidade = quantidade;
        }
    }
}
