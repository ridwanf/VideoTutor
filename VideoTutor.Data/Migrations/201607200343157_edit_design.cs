namespace VideoTutor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_design : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Size", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Videos", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Videos", "Rating", c => c.Int());
            AlterColumn("dbo.Videos", "IsHaveSub", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "IsHaveSub", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Videos", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Videos", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Videos", "Size");
        }
    }
}
