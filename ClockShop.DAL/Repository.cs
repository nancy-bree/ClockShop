using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockShop.DAL
{
    public class Repository<T> where T : class
    {
        internal readonly ClockShopContext Context;
        internal readonly DbSet<T> DbSet;

        public Repository(ClockShopContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            DbSet = context.Set<T>();
        }

        /// <summary>
        /// Read an entity from database.
        /// </summary>
        /// <param name="id">Entity ID.</param>
        /// <returns>Entity.</returns>
        public virtual T GetByID(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Get all entities of type <typeparamref name="T"/> from database.
        /// </summary>
        /// <param name="orderBy"></param>
        /// <returns>Collection of entities.</returns>
        public virtual IEnumerable<T> Get(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbSet;
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        /// <summary>
        /// Insert entity into database.
        /// </summary>
        /// <param name="entity">Entity to insert.</param>
        public virtual void Insert(T entity)
        {
            if (entity.GetType().GetProperty("Created") != null)
            {
                entity.GetType().GetProperty("Created").SetValue(entity, DateTime.Now);
            }
            if (entity.GetType().GetProperty("IsDeleted") != null)
            {
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, false);
            }
            DbSet.Add(entity);
        }

        public virtual void Update(int id)
        {
            T entity = DbSet.Find(id);
            Update(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T entity = DbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                if (entity.GetType().GetProperty("IsDeleted") != null)
                {
                    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                }
                if (entity.GetType().GetProperty("DeletedDate") != null)
                {
                    entity.GetType().GetProperty("DeletedDate").SetValue(entity, DateTime.Now);
                }
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }
    }
}
