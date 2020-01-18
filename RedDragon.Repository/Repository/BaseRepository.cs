using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using RedDragon.Repository.Context;
using RedDragon.Domain.Inteface.Repository;
using RedDragon.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RedDragon.Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        private readonly RedDragonContext Context;

        public BaseRepository(IContextManager contextManager)
        {
            this.Context = contextManager.GetContext();
            this.DbSet = Context.Set<TEntity>();

        }

        ////public IDbConnection Connection
        ////{
        ////    get
        ////    {
        ////        return new SqlConnection(GetConnectionString("RedDragonConn").ConnectionString);
        ////    }
        ////}

        public virtual void Adicionar(TEntity obj)
        {
            var entry = this.Context.Entry(obj);
            DbSet.Add(obj);
            entry.State = EntityState.Added;
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = this.Context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Remover(TEntity obj)
        {
            var entry = this.Context.Entry(obj);
            DbSet.Remove(obj);
            entry.State = EntityState.Deleted;
        }

        public virtual TEntity ObterPorId(int id)
        {
            var resultado = this.DbSet.Find(id);
            return resultado;
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return this.DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int pagina, int registros)
        {
            var resultado = this.DbSet.Take(pagina).Skip(registros);
            return this.DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}