using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Models
{
    public interface IEntity
    {
        /// <summary>
        /// The ID of the entity
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Date entity was created
        /// </summary>
        DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last date Modified
        /// </summary>
        DateTime? DateModified { get; set; }
    }
}
