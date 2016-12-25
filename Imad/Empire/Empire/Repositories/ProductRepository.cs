using Empire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        /// <summary>
        /// Constructs the class with the initialization of the database context.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ProductRepository(EmpireDBContext context)
            : base(context)
        {
        }
    }
}
