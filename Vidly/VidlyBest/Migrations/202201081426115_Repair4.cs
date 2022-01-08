namespace VidlyBest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repair4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        UserName = c.String(),
                        DrivingLicense = c.String(),
                        Name = c.String(),
                        Street = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
