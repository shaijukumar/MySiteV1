namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentDatas", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContentDatas", "Title");
        }
    }
}
