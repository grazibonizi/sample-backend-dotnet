using FW_Relational_Backend.Abstraction.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.Abstraction.DAL.Base
{
    public interface IReadOnly<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] relatedEntities);
        List<TEntity> Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] relatedEntities);
        Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] relatedEntities);
    }
}
