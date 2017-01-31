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
    public class EFRepository<TEntity, TId> : EFReadOnly<TEntity>,
        IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : struct
    {
        public EFRepository(DbContext context)
            : base(context)
        {
        }

        public TEntity ReadById(TId id, params Expression<Func<TEntity, object>>[] relatedEntities)
        {
            var query = Query(relatedEntities);
            //OBS: na conversão Linq - SQL isso funciona
            //http://stackoverflow.com/questions/10402029/ef-object-comparison-with-generic-types
            return query.Single(x => (object)x.Id == (object)id);
        }

        public Task<TEntity> ReadByIdAsync(TId id, params Expression<Func<TEntity, object>>[] relatedEntities)
        {
            var query = Query(relatedEntities);
            //OBS: na conversão Linq - SQL isso funciona
            //http://stackoverflow.com/questions/10402029/ef-object-comparison-with-generic-types
            return query.SingleAsync(x => (object)x.Id == (object)id);
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
        
        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
