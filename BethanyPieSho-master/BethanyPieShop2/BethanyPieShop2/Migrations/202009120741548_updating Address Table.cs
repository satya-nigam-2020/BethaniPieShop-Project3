namespace BethanyPieShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingAddressTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Addresses");
            AddColumn("dbo.Addresses", "AddressId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Addresses", "FName", c => c.String());
            AddPrimaryKey("dbo.Addresses", "AddressId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.Addresses", "FName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Addresses", "AddressId");
            AddPrimaryKey("dbo.Addresses", "FName");
        }
    }
}
