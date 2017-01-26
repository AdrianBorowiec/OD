namespace OD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieHashowania : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Code");
        }
    }
}
