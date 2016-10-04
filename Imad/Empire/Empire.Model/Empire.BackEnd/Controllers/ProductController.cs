using Empire.Business.QueryHandler;
using Empire.Model.DTOs;
using Empire.Model.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Empire.BackEnd.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IEnumerable<ProductGridDto> Get()
        {
            ProductQueryHandler queryHandler = new ProductQueryHandler();

            // ToDo: transform ProductData into ProductGridDto
            // AutoMapper ??

            var list = new List<ProductGridDto>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new ProductGridDto { Id = i, Name = "Name 0" + i });
            }

            return list;
        }

        // GET: api/Product/5
        public ProductDetailDto Get(int id)
        {
            return new ProductDetailDto { Id = id, Name = "Name 0" + id, Description = "Description 0" + id };
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
