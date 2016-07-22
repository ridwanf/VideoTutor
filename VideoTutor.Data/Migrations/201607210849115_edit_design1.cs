namespace VideoTutor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_design1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Videos", "Technology");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "Technology", c => c.String());
        }
    }
}
