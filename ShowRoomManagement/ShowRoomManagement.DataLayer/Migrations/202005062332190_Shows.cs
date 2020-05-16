namespace ShowRoomManagement.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shows : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        BikeId = c.Int(nullable: false, identity: true),
                        BikeName = c.String(),
                        BikePrice = c.Double(nullable: false),
                        DiscBrakes = c.Int(nullable: false),
                        Milage = c.Int(nullable: false),
                        BikeCC = c.Int(nullable: false),
                        BikeImages = c.Binary(),
                        BrandName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BikeId)
                .ForeignKey("dbo.Brands", t => t.BrandName)
                .Index(t => t.BrandName);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.BrandName);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(maxLength: 128),
                        BikeId = c.Int(nullable: false),
                        BikePrice = c.Double(),
                        EMI = c.Double(),
                        EMIMonths = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Bikes", t => t.BikeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.BikeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "BikeId", "dbo.Bikes");
            DropForeignKey("dbo.Bikes", "BrandName", "dbo.Brands");
            DropIndex("dbo.Transactions", new[] { "BikeId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Bikes", new[] { "BrandName" });
            DropTable("dbo.Customers");
            DropTable("dbo.Transactions");
            DropTable("dbo.Brands");
            DropTable("dbo.Bikes");
        }
    }
}
