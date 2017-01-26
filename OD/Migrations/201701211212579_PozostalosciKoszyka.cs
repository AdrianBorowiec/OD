namespace OD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PozostalosciKoszyka : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(),
                        CreateDT = c.DateTime(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Orders", "OrderDT", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "OrderStatus", c => c.Int());
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "OrderCreateDT");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderCreateDT", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductId" });
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "TotalAmount", c => c.Int());
            DropColumn("dbo.Orders", "OrderDT");
            DropTable("dbo.Carts");
        }
    }
}
