namespace BethanyPieShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStatuspropertyinAddressUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddressUsers", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddressUsers", "Status");
        }
    }
}
