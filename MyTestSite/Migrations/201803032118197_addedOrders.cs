namespace MyTestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Bill = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "Id" });
            DropTable("dbo.Orders");
        }
    }
}
