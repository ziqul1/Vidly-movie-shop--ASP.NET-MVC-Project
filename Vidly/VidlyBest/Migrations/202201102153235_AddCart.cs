namespace VidlyBest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Products = c.String(),
                    UserData = c.String(),
                });
                
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        MovieId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.MovieId);
            
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "Username", c => c.String());
            AddColumn("dbo.Orders", "FirstName", c => c.String());
            AddColumn("dbo.Orders", "LastName", c => c.String());
            AddColumn("dbo.Orders", "Address", c => c.String());
            AddColumn("dbo.Orders", "City", c => c.String());
            AddColumn("dbo.Orders", "State", c => c.String());
            AddColumn("dbo.Orders", "PostalCode", c => c.String());
            AddColumn("dbo.Orders", "Country", c => c.String());
            AddColumn("dbo.Orders", "Phone", c => c.String());
            AddColumn("dbo.Orders", "Email", c => c.String());
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Orders", "OrderId");
            DropColumn("dbo.Orders", "Products");
            DropColumn("dbo.Orders", "UserData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserData", c => c.String());
            AddColumn("dbo.Orders", "Products", c => c.String());
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Carts", "MovieId", "dbo.Movies");
            DropIndex("dbo.OrderDetails", new[] { "MovieId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Carts", new[] { "MovieId" });
            DropPrimaryKey("dbo.Orders");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "Phone");
            DropColumn("dbo.Orders", "Country");
            DropColumn("dbo.Orders", "PostalCode");
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "Address");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "FirstName");
            DropColumn("dbo.Orders", "Username");
            DropColumn("dbo.Orders", "OrderId");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Carts");
            AddPrimaryKey("dbo.Orders", "Id");
        }
    }
}
