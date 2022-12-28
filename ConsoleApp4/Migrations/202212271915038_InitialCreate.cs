namespace ConsoleApp4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        NamePerson = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        PhoneModel = c.Int(nullable: false),
                        PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.PositionPersons",
                c => new
                    {
                        Position_PositionId = c.Int(nullable: false),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Position_PositionId, t.Person_PersonId })
                .ForeignKey("dbo.Positions", t => t.Position_PositionId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Position_PositionId)
                .Index(t => t.Person_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionPersons", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.PositionPersons", "Position_PositionId", "dbo.Positions");
            DropForeignKey("dbo.Phones", "PersonId", "dbo.People");
            DropIndex("dbo.PositionPersons", new[] { "Person_PersonId" });
            DropIndex("dbo.PositionPersons", new[] { "Position_PositionId" });
            DropIndex("dbo.Phones", new[] { "PersonId" });
            DropTable("dbo.PositionPersons");
            DropTable("dbo.Positions");
            DropTable("dbo.Phones");
            DropTable("dbo.People");
        }
    }
}
