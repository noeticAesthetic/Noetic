namespace Noetic.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        StreetBilling = c.String(maxLength: 100),
                        CityBilling = c.String(maxLength: 100),
                        StateBilling = c.String(),
                        ZipCodeBilling = c.String(),
                        StreetShipping = c.String(maxLength: 100),
                        CityShipping = c.String(maxLength: 100),
                        StateShipping = c.String(),
                        ZipCodeShipping = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderId = c.String(maxLength: 128),
                        ProductId = c.String(),
                        ProductName = c.String(maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        OrderStatus = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 20));
            DropColumn("dbo.Products", "Quantity");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Customers");
        }
    }
}
