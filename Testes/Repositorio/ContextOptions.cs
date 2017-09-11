using Microsoft.EntityFrameworkCore;

namespace Testes.Repositorio
{
    public static class ContextOptions<T> where T : DbContext
    {
        public static DbContextOptions<T> GetOptions()
        {
            var options = new DbContextOptionsBuilder<T>();
            options.UseSqlServer("Server = .; Database = Desafio; Trusted_Connection = True;");
            return options.Options;
        }
    }
}
