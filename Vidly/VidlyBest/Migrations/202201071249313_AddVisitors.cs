namespace VidlyBest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisitors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitorNumber",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.VisitorNumber");
        }
    }
}
