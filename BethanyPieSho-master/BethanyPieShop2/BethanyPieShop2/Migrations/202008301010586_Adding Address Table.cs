namespace BethanyPieShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAddressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        FName = c.String(nullable: false, maxLength: 128),
                        LName = c.String(nullable: false, maxLength: 20),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Zipcode = c.Long(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PhoneNo = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FName)
                .ForeignKey("dbo.Registers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "UserId", "dbo.Registers");
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.Addresses");
        }
    }
}
