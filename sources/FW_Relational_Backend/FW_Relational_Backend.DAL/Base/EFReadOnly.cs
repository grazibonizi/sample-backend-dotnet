using FW_Relational_Backend.Abstraction.DAL;
using FW_Relational_Backend.Abstraction.DAL.Base;
using FW_Relational_Backend.Abstraction.DTL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.DAL
{
    public class EFReadOnly<TEntity> : IReadOnly<TEntity> 
        where TEntity : class
    {
        protected DbContext context;
        protected DbSet<TEntity> dbSet;

        public EFReadOnly(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] relatedEntities)
        {
            var query = dbSet.AsQueryable();
            foreach (var relatedEntity in relatedEntities)
            {
                query = query.Include(relatedEntity);
            }
            return query;
        }

        public List<TEntity> Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] relatedEntities)
        {
            var query = Query(relatedEntities);
            if (predicate == null)
                return query.ToList();
            else
                return query.Where(predicate).ToList();
        }

        public Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] relatedEntities)
        {
            var query = Query(relatedEntities);
            if (predicate == null)
                return query.ToListAsync();
            else
                return query.Where(predicate).ToListAsync();
        }
    }
}
