using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Models.DtoModels
{
    public class ProductDto : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
