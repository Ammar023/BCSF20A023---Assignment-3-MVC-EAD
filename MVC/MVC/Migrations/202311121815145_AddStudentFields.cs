namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "RollNo", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "RollNo");
        }
    }
}
