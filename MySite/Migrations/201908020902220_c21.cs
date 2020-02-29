namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentDatas", "ContentTitle", c => c.Int(nullable: false));
            AddColumn("dbo.ContentDatas", "ContentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContentDatas", "ContentStatus");
            DropColumn("dbo.ContentDatas", "ContentTitle");
        }
    }
}
