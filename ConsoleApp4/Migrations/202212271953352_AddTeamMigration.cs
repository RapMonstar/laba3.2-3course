namespace ConsoleApp4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "PersonId", "dbo.People");
            DropIndex("dbo.Phones", new[] { "PersonId" });
            AddColumn("dbo.People", "PhoneId", c => c.Int());
            AddColumn("dbo.Phones", "Phone_PhoneId", c => c.Int());
            CreateIndex("dbo.People", "PhoneId");
            CreateIndex("dbo.Phones", "Phone_PhoneId");
            AddForeignKey("dbo.Phones", "Phone_PhoneId", "dbo.Phones", "PhoneId");
            AddForeignKey("dbo.People", "PhoneId", "dbo.Phones", "PhoneId");
            DropColumn("dbo.Phones", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "PersonId", c => c.Int());
            DropForeignKey("dbo.People", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Phones", "Phone_PhoneId", "dbo.Phones");
            DropIndex("dbo.Phones", new[] { "Phone_PhoneId" });
            DropIndex("dbo.People", new[] { "PhoneId" });
            DropColumn("dbo.Phones", "Phone_PhoneId");
            DropColumn("dbo.People", "PhoneId");
            CreateIndex("dbo.Phones", "PersonId");
            AddForeignKey("dbo.Phones", "PersonId", "dbo.People", "PersonId");
        }
    }
}
