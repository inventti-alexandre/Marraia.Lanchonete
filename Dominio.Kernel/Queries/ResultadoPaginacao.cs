using System;
using System.Collections.Generic;

namespace Dominio.Kernel.Queries
{
    public sealed class ResultadoPaginacao<T>
    {
        public int Total { get; private set; }
        public int Pagina { get; private set; }
        public int TotalPaginas { get; private set; }
        public int TotalPorPagina { get; private set; }

        public IList<T> Resultados { get; private set; }

        public ResultadoPaginacao(IList<T> resultados, int total, int pagina, int totalPagina)
        {
            Resultados = resultados;
            Pagina = pagina;
            Total = total;
            TotalPorPagina = totalPagina;
            TotalPaginas = (int)Math.Ceiling((double)Total / TotalPorPagina);
        }
    }
}
