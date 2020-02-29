namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db12211 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppFields", "FieldOrder", c => c.String());
            AddColumn("dbo.AppFields", "FieldTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.AppFields", "FieldType", c => c.String());
            AddColumn("dbo.AppFields", "FieldDescription", c => c.String());
            AddColumn("dbo.AppFields", "FieldRef", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppFields", "FieldRef");
            DropColumn("dbo.AppFields", "FieldDescription");
            DropColumn("dbo.AppFields", "FieldType");
            DropColumn("dbo.AppFields", "FieldTypeID");
            DropColumn("dbo.AppFields", "FieldOrder");
        }
    }
}
