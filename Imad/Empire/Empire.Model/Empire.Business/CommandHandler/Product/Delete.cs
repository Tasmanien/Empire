using Empire.DataAccess;
using Empire.DataAccess.Repositories;
using Empire.Model.DTOs;
using Empire.Model.DTOs.Product;

namespace Empire.Business.CommandHandler.Product
{
    public class Delete
    {
        private readonly ProductRepository _productRepository;

        public void Handle(ProductDetailDto productDto)
        {
            try
            {
                DeleteProduct(productDto.Id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Delete-Product : " + ex.Message);
            }
        }

        private void DeleteProduct(int id)
        {
            using (var context = new EmpireContext())
            {
                var product = _productRepository.Get(id);

                if (product == null)
                {
                    throw new System.Exception("The Id provided is does not exist");
                }

                _productRepository.Delete(product.Id);
            }
        }

        public void Handle(ProductGridDto productDto)
        {
            try
            {
                DeleteProduct(productDto.Id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Delete-Product : " + ex.Message);
            }
        }
    }
}
