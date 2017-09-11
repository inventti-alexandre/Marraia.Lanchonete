using Dominio.Kernel.Validacao;

namespace Dominio.Modelos
{
    public class Lanche : Entidade
    {
        public string Nome { get; private set; }

        private Lanche()
        {
        }

        public Lanche(string nome)
        {
            new Guard()
                .NotNullOrEmpty("Nome", nome)
                .Validate();

            Nome = nome;
        }

        public void Alterar(string novoNome)
        {
            new Guard()
                .NotNullOrEmpty("Nome", novoNome)
                .Validate();

            Nome = novoNome;
        }
    }
}
