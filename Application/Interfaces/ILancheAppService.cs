using Dominio.Kernel.Queries;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILancheAppService
    {
        Task<Lanche> Obter(int id);

        Task Adicionar(string nome);

        Task<ResultadoPaginacao<Lanche>> ListarTodos(int paginaAtual, int totalPorPagina);

        Task Excluir(int id);

        Task Atualizar(int id, string novoNome);
    }
}
