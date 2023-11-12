namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacherKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Tid = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Tid);
            
            AddColumn("dbo.Courses", "Tid", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Tid");
            AddForeignKey("dbo.Courses", "Tid", "dbo.Teachers", "Tid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Tid", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "Tid" });
            DropColumn("dbo.Courses", "Tid");
            DropTable("dbo.Teachers");
        }
    }
}
