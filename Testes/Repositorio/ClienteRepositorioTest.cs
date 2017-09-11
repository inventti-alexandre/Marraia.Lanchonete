using Dominio.Modelos;
using Infra.Repositorio;
using Infra.Repositorio.Contexto;

using Xunit;
using System.Linq;
using System.Threading.Tasks;

namespace Testes.Repositorio
{
    public class ClienteRepositorioTest
    {
        //[Fact]
        //[Trait("Integration", "")]
        //[Trait("Repositorios", "")]
        public async  Task CriarObterAtualizarExcluirCliente()
        {
            using (var context = new LanchoneteContext(ContextOptions<LanchoneteContext>.GetOptions()))
            {
                var repo = new ClienteRepositorio(context);
                var cliente = new Cliente("Fernando");
                await repo.Insert(cliente);

                Assert.NotEqual(default(int), cliente.Id);

                var clienteObter = await repo.GetById(cliente.Id);

                Assert.Equal("Fernando", clienteObter.Nome);

                cliente.Alterar("Mendes");

                await repo.Update(cliente);

                var clienteAtualizado = await repo.GetAllBy(c => c.Nome.StartsWith("Mend"));

                Assert.Equal("Mendes", clienteAtualizado.FirstOrDefault().Nome);

                await repo.Delete(cliente);

                var clienteExcluido = await repo.GetById(cliente.Id);

                Assert.Null(clienteExcluido);

            }
        }
    }
}
