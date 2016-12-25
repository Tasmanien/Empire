using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Repositories
{
    /// <summary>
    /// This class serves as base repository for the other classes
    /// </summary>
    public abstract class BaseRepository<T> : SimpleBaseRepository, IDisposable
        where T : Entity
    {
        /// <summary>
        /// Constructor accepting the context
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(EmpireDBContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Removes the entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Remove(T entity)
        {
            Context.EntitySet<T>().Remove(entity);
        }

        /// <summary>
        /// Returns the current item by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByID(int id)
        {
            return Context.EntitySet<T>().FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// Returns all the items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return Context.EntitySet<T>().ToList();
        }

        /// <summary>
        /// Returns items based on the linq where filter provided
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IQueryable<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return Context.EntitySet<T>()
                            .Where(filter);
        }

        /// <summary>
        /// Returns an IQueryable of the current set
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetQueryable()
        {
            return Context.EntitySet<T>();
        }

        /// <summary>
        /// Saves or updates the user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void SaveOrUpdate(T entity)
        {
            if (entity.ID == 0)
                SetEntityStateAdded(entity);
            else
                SetEntityStateModified(entity);
        }

        /// <summary>
        /// Sets the Entry State to Modified
        /// </summary>
        /// <param name="entity"></param>
        /// <remarks>Not to be used directly! Only for testing purposes</remarks>
        protected virtual void SetEntityStateModified(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Sets the entry state to added
        /// </summary>
        /// <param name="entity"></param>
        /// <remarks>Not to be used directly! Only for testing purposes</remarks>
        protected virtual void SetEntityStateAdded(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }
    }

    /// <summary>
    /// An enhanced base repository adding more UnitOfWork and Logging facilities
    /// </summary>
    public abstract class SimpleBaseRepository : IDisposable
    {
        /// <summary>
        /// The EF Context to use in these repositories
        /// </summary>
        protected EmpireDBContext Context;

        /// <summary>
        /// Constructor accepting the context
        /// </summary>
        /// <param name="context"></param>
        public SimpleBaseRepository(EmpireDBContext context)
        {
            Context = context;
        }

        private bool disposed = false;

        /// <summary>
        /// Allow for a dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose the current repository
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Commits the transaction
        /// </summary>
        /// <returns>The amount of effected records</returns>
        public int Commit()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    throw new ApplicationException(string.Format("Property: {0} Error: {1}", validationErrors.ValidationErrors.First().PropertyName, validationErrors.ValidationErrors.First().ErrorMessage));
                }
            }

            return -1;
        }
    }
}
