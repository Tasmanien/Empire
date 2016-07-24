using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Empire.DataAccessLayer
{
	public class EmpireContext : DbContext
	{
		public EmpireContext()
			: base("name=Empire")
		{

		}

		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<ProductDetail> ProductDetails { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

		}

		public override int SaveChanges()
		{
			ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;

			IEnumerable<ObjectStateEntry> objectStateEntries = context.ObjectStateManager
				.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
				.Where(e => e.IsRelationship == false && e.Entity is EntityBase);

			DateTime currentTime = DateTime.Now;

			foreach (ObjectStateEntry entry in objectStateEntries)
			{
				EntityBase entityBase = entry.Entity as EntityBase;
				if (entityBase != null)
				{
					if (entry.State == EntityState.Added)
					{
						entityBase.CreatedDate = currentTime;
					}

					entityBase.UpdatedDate = currentTime;
				}
			}

			return base.SaveChanges();
		}
	}
}
