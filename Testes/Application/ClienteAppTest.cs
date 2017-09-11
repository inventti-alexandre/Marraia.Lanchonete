using Application;
using Application.Interfaces;
using Dominio.Interfaces;
using Dominio.Modelos;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Application
{
    public class ClienteAppTest
    {
        private Mock<IClienteRepositorio> _mockClienteRepositorio;
        private IClienteAppService _appService;

        [Fact]
        [Trait("Integration", "")]
        [Trait("Application", "")]
        public async Task CriarObterAtualizarExcluirCliente()
        {
            _mockClienteRepositorio = new Mock<IClienteRepositorio>();
            _appService = new ClienteAppService(_mockClienteRepositorio.Object);
            /* Inserindo */
            var obj = "Ipppppp";

            /* Especificando retorno para o metodo em questão */
            _mockClienteRepositorio.Setup(x => x.Insert(It.IsAny<Cliente>()))
                                                   .Returns(Task.CompletedTask);
            
            await _mockClienteRepositorio.Object.Insert(It.IsAny<Cliente>());

            await _appService.Adicionar(obj);
        }
    }
}
