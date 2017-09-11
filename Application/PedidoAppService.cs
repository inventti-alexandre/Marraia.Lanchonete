using Application.Interfaces;
using System.Collections.Generic;
using Dominio.Modelos;
using Dominio.Interfaces;
using System.Threading.Tasks;
using Application.Input;
using Dominio.Kernel.Excecoes;
using Dominio.Dto;

namespace Application
{
    public class PedidoAppService : IPedidoAppService
    {
        private IPedidoRepositorio _appPedido { get; }
        private IClienteRepositorio _appCliente { get; }
        private ILancheRepositorio _appLanche { get; }
        private IIngredienteRepositorio _appIngrediente { get; }
        public PedidoAppService(IPedidoRepositorio appPedido, IClienteRepositorio appCliente, 
            IIngredienteRepositorio appIngrediente, ILancheRepositorio appLanche)
        {
            _appPedido = appPedido;
            _appCliente = appCliente;
            _appIngrediente = appIngrediente;
            _appLanche = appLanche;
        }
        public async Task AdicionarPedido(int idCliente, IList<PedidoItemInput> itens)
        {
            var cliente = await _appCliente.GetById(idCliente);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado", idCliente);

            var lista = new List<PedidoItemDto>();
            foreach (var item in itens)
            {
                var lanche = await _appLanche.GetById(item.IdLanche);
                if (lanche == null)
                    throw new NotFoundException("Lanche não encontrado", item.IdLanche);

                foreach (var i in item.Ingredientes)
                {
                    var ingrediente = await _appIngrediente.GetById(i.IdIngrediente);
                    if (ingrediente == null)
                        throw new NotFoundException("Ingrediente não encontrado", i.IdIngrediente);

                    lista.Add(new PedidoItemDto(lanche, ingrediente, i.Quantidade));
                }
            }

            var pedido = new Pedido(cliente, lista);
            pedido.CalcularPedido();

            await _appPedido.Insert(pedido);
        }

        public async Task<Pedido> ObterPedido(int id)
        {
            return await _appPedido.GetById(id);
        }

        public IList<Pedido> ObterPedidosPorCliente(int idCliente)
        {
            return _appPedido.ObterPedidosPorCliente(idCliente);
        }
    }
}
