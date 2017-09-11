using Application.Input;
using Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPedidoAppService
    {
        Task<Pedido> ObterPedido(int id);

        Task AdicionarPedido(int idCliente, IList<PedidoItemInput> itens);

        IList<Pedido> ObterPedidosPorCliente(int idCliente);
    }
}
