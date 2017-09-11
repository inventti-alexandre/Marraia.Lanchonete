using Dominio.Interfaces;
using Dominio.Modelos;
using Infra.Repositorio.Contexto;

namespace Infra.Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente, LanchoneteContext>, IClienteRepositorio
    {
        public ClienteRepositorio(LanchoneteContext context) : base(context)
        {
        }
    }
}
