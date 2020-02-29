namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContentDatas", "ContentTitle", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContentDatas", "ContentTitle", c => c.Int(nullable: false));
        }
    }
}
