using System.Data.Entity.Migrations;

namespace Empire.DataAccessLayer.Migrations
{
	public partial class UpdateEntityBase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetails", "Product_Id", "dbo.Products");
            DropPrimaryKey("dbo.ProductDetails");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.ProductDetails", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ProductDetails", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductDetails", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "UpdatedDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.ProductDetails", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddForeignKey("dbo.ProductDetails", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetails", "Product_Id", "dbo.Products");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.ProductDetails");
            AlterColumn("dbo.Products", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductDetails", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductDetails", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductDetails", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.ProductDetails", "Id");
            AddForeignKey("dbo.ProductDetails", "Product_Id", "dbo.Products", "Id");
        }
    }
}
