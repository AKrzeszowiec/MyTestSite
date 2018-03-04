namespace MyTestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ShippingDetails_ShippingId", "dbo.ShippingDetails");
            DropIndex("dbo.Orders", new[] { "ShippingDetails_ShippingId" });
            DropIndex("dbo.AspNetUsers", new[] { "ShippingDetails_ShippingId" });
            DropColumn("dbo.Orders", "ShippingId");
            DropColumn("dbo.AspNetUsers", "ShippingId");
            RenameColumn(table: "dbo.Orders", name: "ShippingDetails_ShippingId", newName: "ShippingId");
            RenameColumn(table: "dbo.AspNetUsers", name: "ShippingDetails_ShippingId", newName: "ShippingId");
            AlterColumn("dbo.Orders", "ShippingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ShippingId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ShippingId", c => c.Int());
            CreateIndex("dbo.Orders", "ShippingId");
            CreateIndex("dbo.AspNetUsers", "ShippingId");
            AddForeignKey("dbo.Orders", "ShippingId", "dbo.ShippingDetails", "ShippingId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShippingId", "dbo.ShippingDetails");
            DropIndex("dbo.AspNetUsers", new[] { "ShippingId" });
            DropIndex("dbo.Orders", new[] { "ShippingId" });
            AlterColumn("dbo.AspNetUsers", "ShippingId", c => c.String());
            AlterColumn("dbo.Orders", "ShippingId", c => c.Int());
            AlterColumn("dbo.Orders", "ShippingId", c => c.String());
            RenameColumn(table: "dbo.AspNetUsers", name: "ShippingId", newName: "ShippingDetails_ShippingId");
            RenameColumn(table: "dbo.Orders", name: "ShippingId", newName: "ShippingDetails_ShippingId");
            AddColumn("dbo.AspNetUsers", "ShippingId", c => c.String());
            AddColumn("dbo.Orders", "ShippingId", c => c.String());
            CreateIndex("dbo.AspNetUsers", "ShippingDetails_ShippingId");
            CreateIndex("dbo.Orders", "ShippingDetails_ShippingId");
            AddForeignKey("dbo.Orders", "ShippingDetails_ShippingId", "dbo.ShippingDetails", "ShippingId");
        }
    }
}
