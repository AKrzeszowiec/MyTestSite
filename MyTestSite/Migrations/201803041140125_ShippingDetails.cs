namespace MyTestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShippingDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ShippingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Line1 = c.String(nullable: false),
                        Line2 = c.String(),
                        Line3 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(),
                        Country = c.String(nullable: false),
                        GiftWrap = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShippingId);
            
            AddColumn("dbo.Orders", "ShippingId", c => c.String());
            AddColumn("dbo.Orders", "ShippingDetails_ShippingId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ShippingId", c => c.String());
            AddColumn("dbo.AspNetUsers", "ShippingDetails_ShippingId", c => c.Int());
            CreateIndex("dbo.Orders", "ShippingDetails_ShippingId");
            CreateIndex("dbo.AspNetUsers", "ShippingDetails_ShippingId");
            AddForeignKey("dbo.AspNetUsers", "ShippingDetails_ShippingId", "dbo.ShippingDetails", "ShippingId");
            AddForeignKey("dbo.Orders", "ShippingDetails_ShippingId", "dbo.ShippingDetails", "ShippingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShippingDetails_ShippingId", "dbo.ShippingDetails");
            DropForeignKey("dbo.AspNetUsers", "ShippingDetails_ShippingId", "dbo.ShippingDetails");
            DropIndex("dbo.AspNetUsers", new[] { "ShippingDetails_ShippingId" });
            DropIndex("dbo.Orders", new[] { "ShippingDetails_ShippingId" });
            DropColumn("dbo.AspNetUsers", "ShippingDetails_ShippingId");
            DropColumn("dbo.AspNetUsers", "ShippingId");
            DropColumn("dbo.Orders", "ShippingDetails_ShippingId");
            DropColumn("dbo.Orders", "ShippingId");
            DropTable("dbo.ShippingDetails");
        }
    }
}
