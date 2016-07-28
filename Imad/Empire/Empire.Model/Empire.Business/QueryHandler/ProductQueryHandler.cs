using Empire.DataAccess;
using Empire.DataAccess.Repositories;
using Empire.Model.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Business.QueryHandler
{
    public class ProductQueryHandler
    {
        private ProductRepository _productRepository;

        public IEnumerable<ProductData> GetList(/*Option to filter*/)
        {
            using (var context = new EmpireContext())
            {
                _productRepository = new ProductRepository(context);

                var query = _productRepository.GetData(/*Option to filter*/);

                // Do some more filter here

                query.OrderBy(x => x.Name);

                return query.ToArray();
            }
        }
    }
}
