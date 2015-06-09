namespace PhotoStory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chapter",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoryID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ChapterName = c.String(),
                        ChapterStatus = c.Int(nullable: false),
                        StartTime = c.DateTime(),
                        LastDraftSavedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UploadTime = c.DateTime(nullable: false),
                        FullKey = c.String(),
                        FileName = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ChapterDraftID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photo", "UserID", "dbo.User");
            DropIndex("dbo.Photo", new[] { "UserID" });
            DropTable("dbo.Story");
            DropTable("dbo.User");
            DropTable("dbo.Photo");
            DropTable("dbo.Chapter");
        }
    }
}
