using Application.Interfaces;

using Dominio.Kernel.Queries;
using Dominio.Modelos;
using Dominio.Interfaces;
using Dominio.Kernel.Excecoes;
using System.Threading.Tasks;

namespace Application
{
    public class LancheAppService : ILancheAppService
    {
        private ILancheRepositorio _repo { get; }
        public LancheAppService(ILancheRepositorio repo)
        {
            _repo = repo;
        }
        public async Task Adicionar(string nome)
        {
            var lanche = new Lanche(nome);
            await _repo.Insert(lanche);
        }

        public async Task Atualizar(int id, string novoNome)
        {
            var lanche = await ObterLanche(id);
            lanche.Alterar(novoNome);
            await _repo.Update(lanche);
        }

        public async Task Excluir(int id)
        {
            await _repo.Delete(await ObterLanche(id));
        }

        public async Task<ResultadoPaginacao<Lanche>> ListarTodos(int paginaAtual, int totalPorPagina)
        {
            return await _repo.GetAll(new Paginacao(paginaAtual, totalPorPagina));
        }

        public async Task<Lanche> Obter(int id)
        {
            return await ObterLanche(id);
        }

        private async Task<Lanche> ObterLanche(int id)
        {
            var lanche = await _repo.GetById(id);
            if (lanche == null)
                throw new NotFoundException("Lanche não encontrado", id);

            return lanche;
        }
    }
}
