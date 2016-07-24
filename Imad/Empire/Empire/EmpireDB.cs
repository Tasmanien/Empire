namespace Empire
{
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

        public virtual DbSet<Product> Products { get; set; }
    }
}