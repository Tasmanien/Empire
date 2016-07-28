using Empire.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Empire.DataAccess.Mappings
{
    public class CoreEntityMap<T> : EntityTypeConfiguration<T> where T : EmpireEntity
    {
        public CoreEntityMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
