using System.Data.Entity.Migrations;

namespace Empire.DataAccessLayer.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<EmpireContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Empire.DataAccessLayer.EmpireContext";
        }

        protected override void Seed(EmpireContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
