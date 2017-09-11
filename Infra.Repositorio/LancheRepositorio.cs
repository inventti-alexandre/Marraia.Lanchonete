using Dominio.Interfaces;
using Dominio.Modelos;
using Infra.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorio
{
    public class LancheRepositorio : Repositorio<Lanche, LanchoneteContext>, ILancheRepositorio
    {
        public LancheRepositorio(LanchoneteContext context) : base(context)
        {
        }
    }
}
