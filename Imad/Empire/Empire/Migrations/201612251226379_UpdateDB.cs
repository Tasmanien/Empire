namespace Empire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Products", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DateModified");
            DropColumn("dbo.Products", "DateCreated");
        }
    }
}
