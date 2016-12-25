using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Models.DtoModels
{
    public class EntityDto
    {
        public int ID { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
