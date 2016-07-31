
using Empire.Model.Entities;

namespace Empire.DataAccess.Mappings
{
    public class ProductMap : CoreEntityMap<Product>
   {
        public ProductMap()
        {
            Property(x => x.Name)
                .IsRequired();
        }
   }
}
