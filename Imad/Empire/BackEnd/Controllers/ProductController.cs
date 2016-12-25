using Empire;
using Empire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BackEnd.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        [HttpGet, Route()]
        [ResponseType(typeof(List<Product>))]
        public IHttpActionResult Get()
        {
            var products = new List<Product>();

            using (var ctx = new EmpireDBContext())
            {
                var prods = ctx.Products;

                foreach (var prod in prods)
                {
                    products.Add(new Product() { ID = prod.ID, Name = prod.Name});
                }
            }

            return Json(products);
        }


        [HttpGet, Route("GetData")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetData()
        {
            return Json("Phénnix");
        }

        [HttpGet, Route("description/{id}")]
        //[ResponseType(typeof(IEnumerable<Product>))]
        public IHttpActionResult Get([FromUri]int id)
        {
            Product product = null;

            using (var ctx = new EmpireDBContext())
            {
                product = ctx.Products.Single(x => x.ID == id);
            }

            return Json(product);
        }
    }
}
