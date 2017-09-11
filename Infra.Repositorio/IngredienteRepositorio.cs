using Dominio.Interfaces;
using Dominio.Modelos;
using Infra.Repositorio.Contexto;

namespace Infra.Repositorio
{
    public class IngredienteRepositorio : Repositorio<Ingrediente, LanchoneteContext>, IIngredienteRepositorio
    {
        public IngredienteRepositorio(LanchoneteContext context) : base(context)
        {
        }
    }
}
