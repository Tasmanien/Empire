using AutoMapper;
using Empire.Models;
using Empire.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.App_Start
{
    public static class MappingConfig
    {
        public static void Config()
        {
            Mapper.CreateMap<Product, ProductDto>();
        }
    }
}