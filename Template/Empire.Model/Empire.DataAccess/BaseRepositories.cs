using Empire.Model;
using System;
using System.Linq;

namespace Empire.DataAccess
{
    public abstract class SimpleBaseRepository
    {
        protected EmpireContext Context;

        public SimpleBaseRepository(EmpireContext context)
        {
            Context = context;
        }

        public int Commit()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class BaseRepositories<T> : SimpleBaseRepository where T : EmpireEntity
    {
        public BaseRepositories(EmpireContext context)
            : base(context) { }

        protected void Remove(T entity)
        {
            Context.EntitySet<T>().Remove(entity);
        }

        protected T GetById(int Id)
        {
            return Context.EntitySet<T>().FirstOrDefault(x => x.Id == Id);
        }

        protected IQueryable<T> Get()
        {
            return Context.EntitySet<T>();
        }

        protected void SaveOrUpdate(T entity)
        {
            if (entity.Id == 0)
                SetEntityStateAdded(entity);
            else
                SetEntityStateModified(entity);
        }

        public virtual void SetEntityStateModified(T entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void SetEntityStateAdded(T entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Added;
        }
    }
}
