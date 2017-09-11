using Dominio.Modelos;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        IList<Pedido> ObterPedidosPorCliente(int idCliente);
    }
}
