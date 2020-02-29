namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentDatas",
                c => new
                    {
                        ContentDataId = c.Int(nullable: false, identity: true),
                        ContentTypesId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ContentDataId)
                .ForeignKey("dbo.ContentTypes", t => t.ContentTypesId, cascadeDelete: true)
                .Index(t => t.ContentTypesId);
            
            CreateTable(
                "dbo.ContentTypes",
                c => new
                    {
                        ContentTypesId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContentTypesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentDatas", "ContentTypesId", "dbo.ContentTypes");
            DropIndex("dbo.ContentDatas", new[] { "ContentTypesId" });
            DropTable("dbo.ContentTypes");
            DropTable("dbo.ContentDatas");
        }
    }
}
