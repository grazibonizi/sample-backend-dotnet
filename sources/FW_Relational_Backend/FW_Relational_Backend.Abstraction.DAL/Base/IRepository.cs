using FW_Relational_Backend.Abstraction.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.Abstraction.DAL.Base
{
    public interface IRepository<TEntity, TId> : IReadOnly<TEntity>
        where TEntity : class, IEntity<TId>
        where TId : struct
    {
        TEntity ReadById(TId id, params Expression<Func<TEntity, object>>[] relatedEntities);
        Task<TEntity> ReadByIdAsync(TId id, params Expression<Func<TEntity, object>>[] relatedEntities);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
