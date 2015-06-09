namespace PhotoStory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChapterBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapter", "Blog", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapter", "Blog");
        }
    }
}
