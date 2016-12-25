using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Empire.Models;
using Empire.Repositories;

namespace Empire.Service
{
    public abstract class BaseService<TEntity, TRepo> where TEntity : Entity
                                                    where TRepo : BaseRepository<TEntity>
    {
        protected TRepo repository { get; set; }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetByID(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> func)
        {
            return repository.GetByFilter(func);
        }
    }
}
