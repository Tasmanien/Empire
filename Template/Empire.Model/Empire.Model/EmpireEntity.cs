using System;

namespace Empire.Model
{
    public class EmpireEntity
    {
        /// <summary>
        /// Id of the entity
        /// </summary>
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
