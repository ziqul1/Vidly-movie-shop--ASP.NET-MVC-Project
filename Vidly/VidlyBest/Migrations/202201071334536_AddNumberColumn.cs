namespace VidlyBest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitorNumbers", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitorNumbers", "Number");
        }
    }
}
