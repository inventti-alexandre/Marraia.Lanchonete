using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Repositorio.Contexto.Config
{
    public class LanchoneteDbContextFactory : IDesignTimeDbContextFactory<LanchoneteContext>
    {
        public LanchoneteContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LanchoneteContext>();
            builder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Desafio; Trusted_Connection = True;");
            return new LanchoneteContext(builder.Options);
        }
    }
}
