using Dominio.Kernel.Validacao;

namespace Dominio.Modelos
{
    public class Ingrediente : Entidade
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        private Ingrediente()
        {
        }

        public Ingrediente(string nome, decimal valor)
        {
            new Guard()
                .NotNullOrEmpty("Nome", nome)
                .GreaterThan("Valor", valor, 0)
                .Validate();

            Nome = nome;
            Valor = valor;
        }

        public void Alterar(string nome, decimal valor)
        {
            new Guard()
                .NotNullOrEmpty("Nome", nome)
                .GreaterThan("Valor", valor, 0)
                .Validate();

            Nome = nome;
            Valor = valor;
        }
    }
}
