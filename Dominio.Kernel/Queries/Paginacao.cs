using Dominio.Kernel.Validacao;

namespace Dominio.Kernel.Queries
{
    public sealed class Paginacao
    {
        public Paginacao(int pagina, int totalPagina)
        {
            new Guard()
                .GreaterThan("pagina", pagina, 0)
                .GreaterThan("totalPagina", totalPagina, 0)
                .Validate();

            Pagina = pagina;
            TotalPorPagina = totalPagina;
        }
        public int Pagina { get; private set; }
        public int TotalPorPagina { get; private set; }
        public int TotalPaginacao => (Pagina - 1) * TotalPorPagina;
    }
}
