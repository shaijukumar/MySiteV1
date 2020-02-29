namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db122 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppFields",
                c => new
                    {
                        AppFieldID = c.Int(nullable: false, identity: true),
                        FieldOrder = c.String(),
                        FieldTypeID = c.Int(nullable: false),
                        FieldType = c.String(),
                        FieldDescription = c.String(),
                        FieldRef = c.String(),
                    })
                .PrimaryKey(t => t.AppFieldID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppFields");
        }
    }
}
