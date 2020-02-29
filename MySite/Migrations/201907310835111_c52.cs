namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c52 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContentDatas", "ContentTypesId", "dbo.ContentTypes");
            DropIndex("dbo.ContentDatas", new[] { "ContentTypesId" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.ContentDatas", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContentDatas", "CategoryId");
            AddForeignKey("dbo.ContentDatas", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.ContentDatas", "ContentTypesId");
            DropTable("dbo.ContentTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContentTypes",
                c => new
                    {
                        ContentTypesId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentTypesId);
            
            AddColumn("dbo.ContentDatas", "ContentTypesId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ContentDatas", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ContentDatas", new[] { "CategoryId" });
            DropColumn("dbo.ContentDatas", "CategoryId");
            DropTable("dbo.Categories");
            CreateIndex("dbo.ContentDatas", "ContentTypesId");
            AddForeignKey("dbo.ContentDatas", "ContentTypesId", "dbo.ContentTypes", "ContentTypesId", cascadeDelete: true);
        }
    }
}
