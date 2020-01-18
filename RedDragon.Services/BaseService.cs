using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fred.Domain.Inteface.Repository;
using Fred.Domain.Inteface.Service;

namespace Fred.Services
{

    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Adicionar(TEntity obj)
        {
            this.repository.Adicionar(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            this.repository.Atualizar(obj);
        }

        public virtual void Remover(TEntity obj)
        {
            this.repository.Remover(obj);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return this.repository.ObterPorId(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return this.repository.ObterTodos();
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return this.repository.Pesquisar(predicate);
        }
    }
}
