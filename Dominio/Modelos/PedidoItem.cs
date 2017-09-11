using Dominio.Kernel.Validacao;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Modelos
{
    public class PedidoItem
    {
        public int PedidoId { get; private set; }
        public int QuantidadeIngrediente { get; private set; }
        public int IngredienteId { get; private set; }
        public Ingrediente Ingrediente { get; private set; }
        public Lanche Lanche { get; private set; }
        public int LancheId { get; private set; }
        
        private PedidoItem()
        {
        }

        public PedidoItem (Pedido pedido, Lanche lanche, Ingrediente ingrediente, int qtd)
        {
            new Guard()
            .NotNull("Pedido", pedido)
            .NotNull("Lanche", lanche)
            .NotNull("Ingrediente", ingrediente)
            .GreaterThan("QuantidadeIngrediente", qtd, -1)
            .Validate();

            PedidoId = pedido.Id;
            Lanche = lanche;
            LancheId = lanche.Id;
            Ingrediente = ingrediente;
            IngredienteId = ingrediente.Id;
            QuantidadeIngrediente = qtd;
        }
    }
}
