namespace VideoTutor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_key : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Videos");
            CreateTable(
                "dbo.Videos",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Title = c.String(),
                    Level = c.String(),
                    ReleaseDate = c.DateTime(nullable: false),
                    Author = c.String(),
                    Rating = c.Int(nullable: false),
                    IsHaveSub = c.Boolean(nullable: false),
                    Technology = c.String(),
                    Source = c.String(),
                    IsActive = c.Boolean(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            DropPrimaryKey("dbo.Videos");
            AlterColumn("dbo.Videos", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Videos", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Videos");
            AlterColumn("dbo.Videos", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Videos", "Id");
        }
    }
}
