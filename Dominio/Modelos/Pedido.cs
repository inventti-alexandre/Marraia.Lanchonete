using Dominio.Kernel.Validacao;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Enum;
using Dominio.Dto;

namespace Dominio.Modelos
{
    public class Pedido : Entidade
    {
        private const decimal _PROMOCAOLIGHT = 10.00M;
        private const decimal _PROMOCAOCARNE = 66.66M;
        private const decimal _PROMOCAOQUEIJO = 66.66M;

        public Cliente Cliente { get; private set; }
        public IList<PedidoItem> Itens { get; private set; }
        public decimal Valor { get; private set; }

        private Pedido()
        {
        }

        public Pedido(Cliente cliente, IList<PedidoItemDto> itens)
        {
            new Guard()
                .NotNull("Cliente", cliente)
                .HasMoreThanOne("itens", itens)
                .Validate();

            Cliente = cliente;

            Itens = new List<PedidoItem>();

            foreach (var item in itens)
            {
                Itens.Add(new PedidoItem(this, item.Lanche, item.Ingrediente, item.Quantidade));
            }
        }

        public void CalcularPedido()
        {
            var listLanches = this.Itens.GroupBy(x => x.Lanche.Id)
                                  .Select(g => g.First())
                                  .ToList();

            var valorTotal = 0.00M;

            foreach (var item in listLanches)
            {
                var ingredientes = this.Itens.Where(a => a.Lanche.Id == item.Lanche.Id).ToList();

                valorTotal = valorTotal + CalcularQueijo(ingredientes);
                valorTotal = valorTotal + CalcularCarne(ingredientes);
                valorTotal = valorTotal + CalcularOutros(ingredientes);
                valorTotal = CalcularLight(ingredientes, valorTotal);
            }

            this.Valor = valorTotal;
        }

        private decimal CalcularQueijo(List<PedidoItem> ingredientes)
        {
            var queijo = ingredientes.Where(a => a.Ingrediente.Id == (int)TipoIngrediente.Queijo).FirstOrDefault();
            var valorTotal = 0.00M;

            var muitoQueijo = (int)(queijo.QuantidadeIngrediente / 3);
            if (muitoQueijo > 0)
            {
                var valorQueijo = (queijo.QuantidadeIngrediente * queijo.Ingrediente.Valor);
                valorTotal = valorTotal + (valorQueijo * (_PROMOCAOQUEIJO / 100));
            }
            else
                valorTotal = valorTotal + (queijo.QuantidadeIngrediente * queijo.Ingrediente.Valor);

            return valorTotal;
        }

        private decimal CalcularCarne(List<PedidoItem> ingredientes)
        {
            var carne = ingredientes.Where(a => a.Ingrediente.Id == (int)TipoIngrediente.Hamburguer).FirstOrDefault();
            var valorTotal = 0.00M;

            var muitaCarne = (int)(carne.QuantidadeIngrediente / 3);
            if (muitaCarne > 0)
            {
                var valorCarne = (carne.QuantidadeIngrediente * carne.Ingrediente.Valor);
                valorTotal = valorTotal + (valorCarne * (_PROMOCAOCARNE / 100));
            }
            else
                valorTotal = valorTotal + (carne.QuantidadeIngrediente * carne.Ingrediente.Valor);

            return valorTotal;
        }

        private decimal CalcularLight(List<PedidoItem> ingredientes, decimal valorTotal)
        {
            var bacon = ingredientes.Where(a => a.Ingrediente.Id == (int)TipoIngrediente.Bacon).FirstOrDefault();
            var alface = ingredientes.Where(a => a.Ingrediente.Id == (int)TipoIngrediente.Alface).FirstOrDefault();

            valorTotal = valorTotal + (bacon.QuantidadeIngrediente * bacon.Ingrediente.Valor);
            valorTotal = valorTotal + (alface.QuantidadeIngrediente * alface.Ingrediente.Valor);


            if (bacon.QuantidadeIngrediente <= 0 && alface.QuantidadeIngrediente > 0)
            {
                valorTotal = valorTotal - (valorTotal * (_PROMOCAOLIGHT / 100));
            }

            return valorTotal;
        }

        private decimal CalcularOutros(List<PedidoItem> ingredientes)
        {
            var outros = ingredientes.Where(a =>
            a.Ingrediente.Id != (int)TipoIngrediente.Bacon
            && a.Ingrediente.Id != (int)TipoIngrediente.Alface 
            && a.Ingrediente.Id != (int)TipoIngrediente.Hamburguer
            && a.Ingrediente.Id != (int)TipoIngrediente.Queijo).ToList();

            var valorTotal = 0.00M;

            valorTotal = valorTotal + (outros.Sum(a => a.QuantidadeIngrediente * a.Ingrediente.Valor));

            return valorTotal;
        }


    }
}
