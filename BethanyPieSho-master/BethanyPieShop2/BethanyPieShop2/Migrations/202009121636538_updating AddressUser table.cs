namespace BethanyPieShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingAddressUsertable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AddressUsers");
            AlterColumn("dbo.AddressUsers", "Address1Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AddressUsers", "Address1Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AddressUsers");
            AlterColumn("dbo.AddressUsers", "Address1Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AddressUsers", new[] { "Address1Id", "UserId" });
        }
    }
}
