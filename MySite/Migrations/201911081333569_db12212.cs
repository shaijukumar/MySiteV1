namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db12212 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppFields", "AppListID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppFields", "AppListID");
        }
    }
}
