using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Empire.DataAccessLayer.Exceptions;
using Empire.Database.Contexts;
using Empire.Database.Entities;

namespace Empire.DataAccessLayer.Repositories
{
	public abstract class BaseRepository<TEntity>
		where TEntity : BaseEntity
	{
		protected readonly EmpireContext Context;
		protected readonly DbSet<TEntity> DbSet;

		protected BaseRepository(EmpireContext context)
		{
			Context = context;
			DbSet = context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
		{
			try
			{
				return DbSet.SqlQuery(query, parameters).ToList();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting items.", ex);
			}
		}

		public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			try
			{
				IQueryable<TEntity> query = DbSet;

				if (filter != null)
				{
					query = query.Where(filter);
				}

				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}

				if (orderBy != null)
				{
					return orderBy(query).ToList();
				}

				return query.ToList();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting items.", ex);
			}
		}

		public virtual TEntity GetById(int id)
		{
			try
			{
				return DbSet.Find(id);
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while getting an item ({id}).", ex);
			}
		}

		public virtual void Insert(TEntity entity)
		{
			try
			{
				DbSet.Add(entity);
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while inserting an item.", ex);
			}
		}

		public virtual void Update(TEntity entity)
		{
			try
			{
				DbSet.Attach(entity);
				Context.Entry(entity).State = EntityState.Modified;
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while updating an item ({entity.Id}).", ex);
			}
		}

		public virtual void Delete(object id)
		{
			try
			{
				TEntity entity = DbSet.Find(id);

				if (Context.Entry(entity).State == EntityState.Detached)
				{
					DbSet.Attach(entity);
				}

				DbSet.Remove(entity);
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while deleting an item ({id}).", ex);
			}
		}
	}
}
