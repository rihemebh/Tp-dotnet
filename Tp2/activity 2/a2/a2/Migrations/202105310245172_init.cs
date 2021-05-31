namespace a2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdOrder = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.IdOrder);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdOrder = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Category_IdOrder = c.Int(),
                        Order_IdOrder = c.Int(),
                    })
                .PrimaryKey(t => t.IdOrder)
                .ForeignKey("dbo.Categories", t => t.Category_IdOrder)
                .ForeignKey("dbo.Orders", t => t.Order_IdOrder)
                .Index(t => t.Category_IdOrder)
                .Index(t => t.Order_IdOrder);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        IdOrder = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdOrder);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_IdOrder", "dbo.Orders");
            DropForeignKey("dbo.Products", "Category_IdOrder", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Order_IdOrder" });
            DropIndex("dbo.Products", new[] { "Category_IdOrder" });
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
