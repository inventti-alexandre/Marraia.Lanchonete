using Application.Interfaces;
using Dominio.Interfaces;
using Dominio.Kernel.Excecoes;
using Dominio.Kernel.Queries;
using Dominio.Modelos;
using System.Threading.Tasks;

namespace Application
{
    public class ClienteAppService : IClienteAppService
    {
        private IClienteRepositorio _repo { get; }
        public ClienteAppService(IClienteRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<Cliente> Obter(int id)
        {
            return await ObterCliente(id);
        }

        public async Task Adicionar(string nome)
        {
            var cliente = new Cliente(nome);
            await _repo.Insert(cliente);
        }

        public async Task<ResultadoPaginacao<Cliente>> ListarTodos(int paginaAtual, int totalPorPagina)
        {
            return await _repo.GetAll(new Paginacao(paginaAtual, totalPorPagina));
        }

        public async Task<ResultadoPaginacao<Cliente>> FiltrarPorNome(string nome, int paginaAtual, int itensPorPagina)
        {
            return await _repo.GetAllBy(
                c => c.Nome.StartsWith(nome),
                new Paginacao(paginaAtual, itensPorPagina));
        }

        public async Task Excluir(int id)
        {
            await _repo.Delete(await ObterCliente(id));
        }

        public async Task Atualizar(int id, string novoNome)
        {
            var cliente = await ObterCliente(id);
            cliente.Alterar(novoNome);
            await _repo.Update(cliente);
        }

        private async Task<Cliente> ObterCliente(int id)
        {
            var cliente = await _repo.GetById(id);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado", id);

            return cliente;
        }
    }
}
