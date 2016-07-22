namespace VideoTutor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_design2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Technology", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Technology");
        }
    }
}
