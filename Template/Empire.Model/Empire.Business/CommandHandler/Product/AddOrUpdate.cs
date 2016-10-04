using Empire.DataAccess;
using Empire.DataAccess.Repositories;
using Empire.Model.DTOs.Product;
using System;

namespace Empire.Business.CommandHandler.Product
{
    public class AddOrUpdate
    {
        private static readonly object locker = new object();

        private ProductRepository _productRepository;

        public void Handle(ProductDetailDto productDto)
        {
            lock (locker)
            {
                try
                {
                    using (var context = new EmpireContext())
                    {
                        _productRepository = new ProductRepository(context);
                        var product = _productRepository.Get(productDto.Id);

                        if (product == null)
                        {
                            // Add
                            product = new Model.Entities.Product();

                            // Use a mapper that can convert from one type to another based on a mapping
                            product.Name = productDto.Name;
                            product.Description = productDto.Description;
                            // ID, DateModified and DateCreated will be updated automatically
                        }
                        else
                        {
                            // Update
                            product.Name = productDto.Name;
                            product.Description = productDto.Description;
                        }

                        _productRepository.SaveOrUpdate(product);
                        _productRepository.Commit();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("AddOrUpdate-Product : " + ex.Message);
                }
            }
        }
    }
}
