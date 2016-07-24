namespace Empire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDescription : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Products", "Decsription", "Description");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Products", "Description", "Decsription");
        }
    }
}
