namespace VidlyBest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Street", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "PostCode", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());

        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "PostCode");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
    }
}
