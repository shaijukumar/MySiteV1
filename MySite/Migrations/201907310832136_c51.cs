namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c51 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContentTypes", "Parent_ContentTypesId", "dbo.ContentTypes");
            DropIndex("dbo.ContentTypes", new[] { "Parent_ContentTypesId" });
            DropColumn("dbo.ContentTypes", "Parent_ContentTypesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContentTypes", "Parent_ContentTypesId", c => c.Int());
            CreateIndex("dbo.ContentTypes", "Parent_ContentTypesId");
            AddForeignKey("dbo.ContentTypes", "Parent_ContentTypesId", "dbo.ContentTypes", "ContentTypesId");
        }
    }
}
