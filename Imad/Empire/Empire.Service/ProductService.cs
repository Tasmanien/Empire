using Empire.Models;
using Empire.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Service
{
    public class ProductService : BaseService<Product, ProductRepository>
    {
        public ProductService()
        {
            repository = new ProductRepository(new EmpireDBContext());
        }
    }
}
