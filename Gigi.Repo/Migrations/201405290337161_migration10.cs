namespace Gigi.Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAddress",
                c => new
                    {
                        CustomerAddressId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.CustomerAddressId);
            
            CreateTable(
                "dbo.CustomerCreditCard",
                c => new
                    {
                        CustomerCreditCardId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CreditCardNumber = c.Int(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        SecurityCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerCreditCardId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CustomerAddress_CustomerAddressId = c.Int(),
                        CustomerCreditCard_CustomerCreditCardId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.CustomerAddress", t => t.CustomerAddress_CustomerAddressId)
                .ForeignKey("dbo.CustomerCreditCard", t => t.CustomerCreditCard_CustomerCreditCardId)
                .Index(t => t.CustomerAddress_CustomerAddressId)
                .Index(t => t.CustomerCreditCard_CustomerCreditCardId);
            
            CreateTable(
                "dbo.Garment",
                c => new
                    {
                        GarmentId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        GarmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GarmentId)
                .ForeignKey("dbo.GarmentType", t => t.GarmentTypeId, cascadeDelete: true)
                .Index(t => t.GarmentTypeId);
            
            CreateTable(
                "dbo.GarmentToGarmentSize",
                c => new
                    {
                        GarmentToGarmentSizeId = c.Int(nullable: false, identity: true),
                        GarmentId = c.Int(nullable: false),
                        GarmentSizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GarmentToGarmentSizeId)
                .ForeignKey("dbo.GarmentSize", t => t.GarmentSizeId, cascadeDelete: true)
                .ForeignKey("dbo.Garment", t => t.GarmentId, cascadeDelete: true)
                .Index(t => t.GarmentId)
                .Index(t => t.GarmentSizeId);
            
            CreateTable(
                "dbo.GarmentSize",
                c => new
                    {
                        GarmentSizeId = c.Int(nullable: false, identity: true),
                        GarmentDescription = c.String(),
                    })
                .PrimaryKey(t => t.GarmentSizeId);
            
            CreateTable(
                "dbo.GarmentType",
                c => new
                    {
                        GarmentTypeId = c.Int(nullable: false, identity: true),
                        GarmentTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.GarmentTypeId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderToGarment",
                c => new
                    {
                        OrderToGarmentId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        GarmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderToGarmentId)
                .ForeignKey("dbo.Garment", t => t.GarmentId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.GarmentId);
            
            CreateTable(
                "dbo.Wishlist",
                c => new
                    {
                        WishlistId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WishlistId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.WishlistToGarment",
                c => new
                    {
                        WishlistToGarmentId = c.Int(nullable: false, identity: true),
                        WishlistId = c.Int(nullable: false),
                        GarmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WishlistToGarmentId)
                .ForeignKey("dbo.Garment", t => t.GarmentId, cascadeDelete: true)
                .ForeignKey("dbo.Wishlist", t => t.WishlistId, cascadeDelete: true)
                .Index(t => t.WishlistId)
                .Index(t => t.GarmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishlistToGarment", "WishlistId", "dbo.Wishlist");
            DropForeignKey("dbo.WishlistToGarment", "GarmentId", "dbo.Garment");
            DropForeignKey("dbo.Wishlist", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.OrderToGarment", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderToGarment", "GarmentId", "dbo.Garment");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Garment", "GarmentTypeId", "dbo.GarmentType");
            DropForeignKey("dbo.GarmentToGarmentSize", "GarmentId", "dbo.Garment");
            DropForeignKey("dbo.GarmentToGarmentSize", "GarmentSizeId", "dbo.GarmentSize");
            DropForeignKey("dbo.Customer", "CustomerCreditCard_CustomerCreditCardId", "dbo.CustomerCreditCard");
            DropForeignKey("dbo.Customer", "CustomerAddress_CustomerAddressId", "dbo.CustomerAddress");
            DropIndex("dbo.WishlistToGarment", new[] { "GarmentId" });
            DropIndex("dbo.WishlistToGarment", new[] { "WishlistId" });
            DropIndex("dbo.Wishlist", new[] { "CustomerId" });
            DropIndex("dbo.OrderToGarment", new[] { "GarmentId" });
            DropIndex("dbo.OrderToGarment", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.GarmentToGarmentSize", new[] { "GarmentSizeId" });
            DropIndex("dbo.GarmentToGarmentSize", new[] { "GarmentId" });
            DropIndex("dbo.Garment", new[] { "GarmentTypeId" });
            DropIndex("dbo.Customer", new[] { "CustomerCreditCard_CustomerCreditCardId" });
            DropIndex("dbo.Customer", new[] { "CustomerAddress_CustomerAddressId" });
            DropTable("dbo.WishlistToGarment");
            DropTable("dbo.Wishlist");
            DropTable("dbo.OrderToGarment");
            DropTable("dbo.Order");
            DropTable("dbo.GarmentType");
            DropTable("dbo.GarmentSize");
            DropTable("dbo.GarmentToGarmentSize");
            DropTable("dbo.Garment");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerCreditCard");
            DropTable("dbo.CustomerAddress");
        }
    }
}
