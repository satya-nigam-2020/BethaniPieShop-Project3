namespace BethanyPieShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAddressUsertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressUsers",
                c => new
                    {
                        Address1Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(nullable: false, maxLength: 70),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Address1Id)
                .ForeignKey("dbo.Registers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressUsers", "UserId", "dbo.Registers");
            DropIndex("dbo.AddressUsers", new[] { "UserId" });
            DropTable("dbo.AddressUsers");
        }
    }
}
