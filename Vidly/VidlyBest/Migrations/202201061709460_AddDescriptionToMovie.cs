namespace VidlyBest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Description");
        }
    }
}
