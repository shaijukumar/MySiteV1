namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentTags",
                c => new
                    {
                        ContentTagId = c.Int(nullable: false, identity: true),
                        ContentTagMasterId = c.Int(nullable: false),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContentTagId)
                .ForeignKey("dbo.ContentTagMasters", t => t.ContentTagMasterId, cascadeDelete: true)
                .Index(t => t.ContentTagMasterId);
            
            CreateTable(
                "dbo.ContentTagMasters",
                c => new
                    {
                        ContentTagMasterId = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.ContentTagMasterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentTags", "ContentTagMasterId", "dbo.ContentTagMasters");
            DropIndex("dbo.ContentTags", new[] { "ContentTagMasterId" });
            DropTable("dbo.ContentTagMasters");
            DropTable("dbo.ContentTags");
        }
    }
}
