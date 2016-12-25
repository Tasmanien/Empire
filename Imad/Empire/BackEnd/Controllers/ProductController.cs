using AutoMapper;
using Empire;
using Empire.Models;
using Empire.Models.DtoModels;
using Empire.Service;
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
    public class ProductController : BaseController
    {
        [HttpGet, Route()]
        [ResponseType(typeof(List<ProductDto>))]
        public IHttpActionResult Get()
        {
            var service = new ProductService();

            var products = service.GetAll();

            return Json(Mapper.Map<IEnumerable<ProductDto>>(products));
        }
    }
}
