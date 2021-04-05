namespace PeopleManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MCreateSerilogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Serilogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        MessageTemplate = c.String(),
                        Level = c.String(maxLength: 128),
                        TimeStamp = c.DateTime(),
                        Exception = c.String(),
                        Properties = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Serilogs");
        }
    }
}
