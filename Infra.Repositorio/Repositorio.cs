using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Dominio.Interfaces;
using Dominio.Kernel.Queries;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public abstract class Repositorio<TEntity, TContext> : IRepositorio<TEntity>, IDisposable
            where TEntity : Entidade
            where TContext : DbContext
    {
        protected TContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repositorio(TContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual Task<TEntity> GetById(int id)
        {
            return DbSet.FirstOrDefaultAsync(c => c.Id == id);
        }
        public Task<List<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToListAsync();
        }

        public async Task<ResultadoPaginacao<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate, Paginacao paginacao)
        {
            var count = DbSet.Where(predicate).Count();

            var results = await DbSet.AsNoTracking()
                .Where(predicate)
                .Skip(paginacao.TotalPaginacao)
                .Take(paginacao.TotalPorPagina)
                .ToListAsync();

            return new ResultadoPaginacao<TEntity>(
                resultados: results,
                total: count,
                pagina: paginacao.Pagina,
                totalPagina: paginacao.TotalPorPagina);
        }

        public async Task<ResultadoPaginacao<TEntity>> GetAll(Paginacao paginacao)
        {
            var count = DbSet.Count();

            var results = await DbSet.AsNoTracking()
                .Skip(paginacao.TotalPaginacao)
                .Take(paginacao.TotalPorPagina)
                .ToListAsync();
            
            return new ResultadoPaginacao<TEntity>(
                resultados: results,
                total: count,
                pagina: paginacao.Pagina,
                totalPagina: paginacao.TotalPorPagina);
        }

        public virtual Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            return Db.SaveChangesAsync();
        }

        public virtual Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            return Db.SaveChangesAsync();
        }

        public virtual Task Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            return Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
