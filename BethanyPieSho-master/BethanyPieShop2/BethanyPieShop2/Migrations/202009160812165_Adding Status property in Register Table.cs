namespace BethanyPieShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStatuspropertyinRegisterTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registers", "AddressStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registers", "AddressStatus");
        }
    }
}
