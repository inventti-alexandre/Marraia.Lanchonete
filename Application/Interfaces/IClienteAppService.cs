using Dominio.Kernel.Queries;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<Cliente> Obter(int id);

        Task Adicionar(string nome);

        Task<ResultadoPaginacao<Cliente>> ListarTodos(int paginaAtual, int totalPorPagina);

        Task<ResultadoPaginacao<Cliente>> FiltrarPorNome(string nome, int paginaAtual, int itensPorPagina);

        Task Excluir(int id);

        Task Atualizar(int id, string novoNome);
    }
}
