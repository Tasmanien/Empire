namespace Empire.DataAccess
{
    using Model;
    using Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmpireContext : DbContext
    {
        // Your context has been configured to use a 'EmpireModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Empire.DataAccess.EmpireModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EmpireModel' 
        // connection string in the application configuration file.
        public EmpireContext()
            : base("name=EmpireModel")
        {
            Configuration.AutoDetectChangesEnabled = true;
        }

        public virtual IDbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is EmpireEntity && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((EmpireEntity)entity.Entity).DateCreated = DateTime.Now.ToUniversalTime();
                }

                ((EmpireEntity)entity.Entity).DateModified = DateTime.Now.ToUniversalTime();
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<TEntity> EntitySet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void Rollback()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
        }

    }
}