namespace OD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawkaDlugosciTelefonu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producers", "PhoneNumber", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producers", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
