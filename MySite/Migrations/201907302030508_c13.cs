namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentAttachments",
                c => new
                    {
                        ContentAttachmentId = c.Int(nullable: false, identity: true),
                        ContentDataId = c.Int(nullable: false),
                        Title = c.String(),
                        FileType = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ContentAttachmentId)
                .ForeignKey("dbo.ContentDatas", t => t.ContentDataId, cascadeDelete: true)
                .Index(t => t.ContentDataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentAttachments", "ContentDataId", "dbo.ContentDatas");
            DropIndex("dbo.ContentAttachments", new[] { "ContentDataId" });
            DropTable("dbo.ContentAttachments");
        }
    }
}
