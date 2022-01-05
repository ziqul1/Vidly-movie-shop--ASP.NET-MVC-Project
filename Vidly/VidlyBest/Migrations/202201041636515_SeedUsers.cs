namespace VidlyBest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69b00548-739e-4c91-9b79-4da4302f6afc', N'guest@vidly.com', 0, N'AEDfQSlvBlPCHua3g2AkYAVglAV2wQpLj0reHDkWdSCn3izMaHTcGHhGz3slJ5DPbw==', N'e636b07c-ded2-44c3-9ce2-efdaf3a1bdd5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'875aa41a-b506-496d-bb72-2738898edcd4', N'admin@vidly.com', 0, N'ANSGc+yEsUOAk+TSBnFtcKDPfTyn8GiIpq/obEsSj+yzRHvkHIY2RviZ9IzH/FNHiw==', N'2abc7d1a-6740-42f1-9402-a03914aa94e9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'41226416-dfa3-41ad-b857-dc464f86b7bd', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'875aa41a-b506-496d-bb72-2738898edcd4', N'41226416-dfa3-41ad-b857-dc464f86b7bd')

");
        }
        
        public override void Down()
        {

        }
    }
}
