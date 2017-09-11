using Dominio.Kernel.Queries;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IIngredienteAppService
    {
        Task<Ingrediente> Obter(int id);

        Task Adicionar(string nome, decimal valor);

        Task<ResultadoPaginacao<Ingrediente>> ListarTodos(int paginaAtual, int totalPorPagina);

        Task Excluir(int id);

        Task Atualizar(int id, string novoNome, decimal valor);
    }
}
