namespace OD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ApartmentNumber = c.String(nullable: false, maxLength: 15),
                        Street = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        ProductType = c.Int(),
                        ImageUrl = c.String(),
                        ProducerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.ProducerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        City = c.String(),
                        Country = c.String(),
                        Nickname = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProducerId", "dbo.Producers");
            DropIndex("dbo.Products", new[] { "ProducerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Producers");
        }
    }
}
