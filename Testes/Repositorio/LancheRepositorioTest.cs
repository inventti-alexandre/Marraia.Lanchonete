using Dominio.Modelos;
using Infra.Repositorio;
using Infra.Repositorio.Contexto;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Repositorio
{
    public class LancheRepositorioTest
    {
        //[Fact]
        //[Trait("Integration", "")]
        //[Trait("Repositorios", "")]
        public async Task CriarObterAtualizarExcluirLanche()
        {
            using (var context = new LanchoneteContext(ContextOptions<LanchoneteContext>.GetOptions()))
            {
                var repo = new LancheRepositorio(context);
                var lanche = new Lanche("X-Mendes");
                await repo.Insert(lanche);

                Assert.NotEqual(default(int), lanche.Id);

                var lancheObter = await repo.GetById(lanche.Id);

                Assert.Equal("X-Mendes", lancheObter.Nome);

                lanche.Alterar("X-Marraia");

                await repo.Update(lanche);

                var lancheAtualizado = await repo.GetAllBy(c => c.Nome.StartsWith("X-Marra"));

                Assert.NotNull(lancheAtualizado.FirstOrDefault().Nome);

                Assert.Equal("X-Marraia", lancheAtualizado.FirstOrDefault().Nome);

                await repo.Delete(lanche);

                var lancheExcluido = await repo.GetById(lanche.Id);

                Assert.Null(lancheExcluido);

            }
        }
    }
}
