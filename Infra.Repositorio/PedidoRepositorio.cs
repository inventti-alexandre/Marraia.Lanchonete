using System.Collections.Generic;
using Dominio.Interfaces;
using Dominio.Modelos;
using Infra.Repositorio.Contexto;
using System.Linq;

namespace Infra.Repositorio
{
    public class PedidoRepositorio : Repositorio<Pedido, LanchoneteContext>, IPedidoRepositorio
    {
        public PedidoRepositorio(LanchoneteContext context) : base(context)
        {
        }

        public IList<Pedido> ObterPedidosPorCliente(int idCliente)
        {
            return DbSet.Where(p => p.Cliente.Id == idCliente).ToList();
        }
    }
}
