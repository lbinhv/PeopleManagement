namespace PeopleManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                    c => new
                    {
                        SubjectId = c.Guid(nullable: false),
                        SubjectName = c.String(nullable: false, maxLength: 50),
                        DateCreated = c.DateTime(nullable: true),
                        DateUpdated = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        NRIC = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 1),
                        Birthday = c.DateTime(nullable: false),
                        AvaiableDate = c.DateTime(nullable: true),
                        DateCreated = c.DateTime(nullable: true),
                        DateUpdated = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UsersSubjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        SubjectId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersSubjects", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersSubjects", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.UsersSubjects", new[] { "SubjectId" });
            DropIndex("dbo.UsersSubjects", new[] { "UserId" });
            DropTable("dbo.UsersSubjects");
            DropTable("dbo.Users");
            DropTable("dbo.Subjects");
        }
    }
}
