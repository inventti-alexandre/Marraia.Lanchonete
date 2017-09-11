using Dominio.Kernel.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Modelos
{
    public class Cardapio
    {
        [Key]
        public int LancheId { get; private set; }
        [Key]
        public int IngredienteId { get; private set; }
        public int Quantidade { get; private set; }

        private Cardapio()
        {
        }

        public Cardapio(int idLanche, int idIngrediente, int quantidade)
        {
            new Guard()
                .GreaterThan("IdLanche", idLanche, 0)
                .GreaterThan("IdIngrediente", idIngrediente, 0)
                .GreaterThan("Quantidade", quantidade, 0)
                .Validate();

            LancheId = idLanche;
            IngredienteId = idIngrediente;
            Quantidade = quantidade;
        }

        public void Alterar (int quantidade)
        {
            new Guard()
                .GreaterThan("Quantidade", quantidade, 0)
                .Validate();

            Quantidade = quantidade;
        }
    }
}
