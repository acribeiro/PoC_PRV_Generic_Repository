using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Providencia.Entidades;
using Providencia.DAL.Contexto;
using System.Linq.Expressions;

namespace Providencia.DAL.Repositorios.Base
{
    public abstract class Repositorio<TEntity> : IDisposable,
       IRepositorio<TEntity> where TEntity : class
    {
        //BancoContexto ctx = new BancoContexto();
        PRV_Model ctx = new PRV_Model();

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll(System.Linq.Expressions.Expression<Func<TEntity, object>> orderbyascending = null,
            System.Linq.Expressions.Expression<Func<TEntity, object>> orderbydescending = null)
        {
            return ctx.Set<TEntity>().OrderBy(orderbyascending);
        }

        public IQueryable<TEntity> IncludeMultiple<TEntity>(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
        where TEntity : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public void Atualizar(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public void SalvarTodos()
        {
            ctx.SaveChanges();
        }

        public void Adicionar(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Excluir(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
            .Where(predicate).ToList()
            .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

    }
}
