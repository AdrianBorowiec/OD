namespace OD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrobaPoprawka : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetails", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
