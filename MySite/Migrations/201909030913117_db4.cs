namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentViews",
                c => new
                    {
                        ContentViewId = c.Int(nullable: false, identity: true),
                        ContentDataId = c.Int(nullable: false),
                        IP = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContentViewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContentViews");
        }
    }
}
