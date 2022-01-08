namespace VidlyBest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repair2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
        }
    }
}
