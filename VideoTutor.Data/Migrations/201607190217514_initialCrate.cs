namespace VideoTutor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Videos");
        }
    }
}
