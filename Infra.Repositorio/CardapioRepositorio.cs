using Dominio.Interfaces;
using Dominio.Modelos;
using Infra.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositorio
{
    public class CardapioRepositorio : DbContext, ICardapioRepositorio
    {
        protected LanchoneteContext Db;
        protected DbSet<Cardapio> DbSet;

        public CardapioRepositorio(LanchoneteContext context) 
        {
            Db = context;
            DbSet = Db.Set<Cardapio>();
        }

        public Cardapio Obter(int idLanche, int idIngrediente)
        {
            return DbSet.AsNoTracking().FirstOrDefault(a => a.LancheId == idLanche && a.IngredienteId == idIngrediente);
        }

        public IList<Cardapio> ObterCardapioPorLanche(int idLanche)
        {
            return DbSet.Where(a => a.LancheId == idLanche).ToList();
        }
    }
}
