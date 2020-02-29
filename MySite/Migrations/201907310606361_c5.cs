namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentTypes", "Parent_ContentTypesId", c => c.Int());
            AlterColumn("dbo.ContentTypes", "ParentId", c => c.Int());
            CreateIndex("dbo.ContentTypes", "Parent_ContentTypesId");
            AddForeignKey("dbo.ContentTypes", "Parent_ContentTypesId", "dbo.ContentTypes", "ContentTypesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentTypes", "Parent_ContentTypesId", "dbo.ContentTypes");
            DropIndex("dbo.ContentTypes", new[] { "Parent_ContentTypesId" });
            AlterColumn("dbo.ContentTypes", "ParentId", c => c.Int(nullable: false));
            DropColumn("dbo.ContentTypes", "Parent_ContentTypesId");
        }
    }
}
