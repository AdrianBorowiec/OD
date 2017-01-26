namespace OD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawkaKlienta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Nickname", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Country");
            DropColumn("dbo.Customers", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AddColumn("dbo.Customers", "Country", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Nickname", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
