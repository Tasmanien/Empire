namespace Empire.Repositories
{
    using Empire.Mappings;
    using Empire.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmpireDBContext : DbContext
    {
        // Your context has been configured to use a 'EmpireDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Empire.EmpireDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EmpireDB' 
        // connection string in the application configuration file.
        public EmpireDBContext()
            : base("name=EmpireDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        #region DbSets
        public virtual DbSet<Product> Products { get; set; }
        #endregion

        /// <summary>
        /// This method is called when all changes need to be persisted
        /// This overridden method automatically fills the create and modified date
        /// and the users that performed these actions
        /// </summary>
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Entity)entity.Entity).DateCreated = DateTime.Now.ToUniversalTime();
                }

                ((Entity)entity.Entity).DateModified = DateTime.Now.ToUniversalTime();
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized,
        /// but before the model has been locked down and used to initialize the context.
        /// The default implementation of this method does nothing, but it can be overridden
        /// in a derived class such that the model can be further configured before it
        /// is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Returns a System.Data.Entity.DbSet instance for access to entities
        /// of the given type in the context and the underlying store.
        /// </summary>
        /// <typeparam name="TEntity">The type entity for which a set should be returned.</typeparam>
        /// <returns>A set for the given entity type.</returns>
        public virtual IDbSet<TEntity> EntitySet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public void Rollback()
        {
            var changedEntries = this.ChangeTracker.Entries()
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