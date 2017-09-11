using Dominio.Kernel.Queries;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : Entidade
    {
        Task<TEntity> GetById(int id);

        Task<List<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate);

        Task<ResultadoPaginacao<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate, Paginacao paginationInput);

        Task<ResultadoPaginacao<TEntity>> GetAll(Paginacao paginationInput);

        Task Update(TEntity entity);

        Task Insert(TEntity entity);

        Task Delete(TEntity entity);
    }
}
