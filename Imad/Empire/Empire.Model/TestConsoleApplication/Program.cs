using Empire.Business.QueryHandler;
using Empire.Model.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var addNewProduct = false;

            if (addNewProduct)
            {
                AddNewProduct();
            }
            else
            {
                ProductQueryHandler queryHandler = new ProductQueryHandler();

                var list = queryHandler.GetList();
            }
        }

        private static void AddNewProduct()
        {
            Empire.Business.CommandHandler.Product.AddOrUpdate command = new Empire.Business.CommandHandler.Product.AddOrUpdate();

            for (int i = 0; i < 10; i++)
            {
                var productDto = new ProductDetailDto();
                productDto.Name = "Product n°" + i;
                productDto.Description = "Description n°" + i;

                command.Handle(productDto);
            }
        }
    }
}
