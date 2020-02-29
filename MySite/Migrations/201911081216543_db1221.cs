namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1221 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppFields", "FieldOrder");
            DropColumn("dbo.AppFields", "FieldTypeID");
            DropColumn("dbo.AppFields", "FieldType");
            DropColumn("dbo.AppFields", "FieldDescription");
            DropColumn("dbo.AppFields", "FieldRef");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppFields", "FieldRef", c => c.String());
            AddColumn("dbo.AppFields", "FieldDescription", c => c.String());
            AddColumn("dbo.AppFields", "FieldType", c => c.String());
            AddColumn("dbo.AppFields", "FieldTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.AppFields", "FieldOrder", c => c.String());
        }
    }
}
