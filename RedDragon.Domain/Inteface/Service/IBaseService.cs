using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RedDragon.Domain.Inteface.Service
{
    public interface IBaseService<TEntity>
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate);
    }
}