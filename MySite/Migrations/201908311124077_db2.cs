namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentDatas", "URLString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContentDatas", "URLString");
        }
    }
}
