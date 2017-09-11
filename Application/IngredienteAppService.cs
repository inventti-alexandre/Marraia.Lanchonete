using Application.Interfaces;

using Dominio.Kernel.Queries;
using Dominio.Modelos;
using Dominio.Interfaces;
using Dominio.Kernel.Excecoes;
using System.Threading.Tasks;

namespace Application
{
    public class IngredienteAppService : IIngredienteAppService
    {
        private IIngredienteRepositorio _repo { get; }
        public IngredienteAppService(IIngredienteRepositorio repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(string nome, decimal valor)
        {
            var obj = new Ingrediente(nome, valor);
            await _repo.Insert(obj);
        }

        public async Task Atualizar(int id, string novoNome, decimal valor)
        {
            var obj = await ObterIngrediente(id);
            obj.Alterar(novoNome, valor);
            await _repo.Update(obj);
        }

        public async Task Excluir(int id)
        {
            await _repo.Delete(await ObterIngrediente(id));
        }

        public async Task<ResultadoPaginacao<Ingrediente>> ListarTodos(int paginaAtual, int totalPorPagina)
        {
            return await _repo.GetAll(new Paginacao(paginaAtual, totalPorPagina));
        }

        public async Task<Ingrediente> Obter(int id)
        {
            return await ObterIngrediente(id);
        }

        private async Task<Ingrediente> ObterIngrediente(int id)
        {
            var lanche = await _repo.GetById(id);
            if (lanche == null)
                throw new NotFoundException("Ingrediente não encontrado", id);

            return lanche;
        }
    }
}
