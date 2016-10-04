using Empire.Model.Datas;
using Empire.Model.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace Empire.DataAccess.Repositories
{
    public class ProductRepository : BaseRepositories<Product>
    {
        public ProductRepository(EmpireContext context)
            : base(context)
        {

        }

        public IQueryable<Product> GetQuery(bool asNoTracking = false)
        {
            if (asNoTracking)
            {
                return Context.EntitySet<Product>().AsNoTracking();
            }

            return Context.EntitySet<Product>();
        }

        public IQueryable<ProductData> GetData(/*Option to filter*/)
        {
            var query = from product in GetQuery(true)
                        select new ProductData
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            DateCreated = product.DateCreated,
                            DateModified = product.DateModified
                        };

            return query;
        }

        public Product Get(int id)
        {
            return GetQuery().SingleOrDefault(x => x.Id == id);
        }

        public Product SaveOrUpdate(Product product)
        {
            base.SaveOrUpdate(product);

            return product;
        }

        public void Delete(int id)
        {
            Product toDelete = Get(id);

            if(toDelete == null)
            {
                throw new Exception("Delete of an unknown Product");
            }

            Context.EntitySet<Product>().Remove(toDelete);
        }
    }
}
