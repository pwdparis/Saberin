namespace ContactManagementApp.Migrations
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
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        EmailAddressID = c.Int(nullable: false, identity: true),
                        EmailType = c.Int(nullable: false),
                        EmailAddressContent = c.String(),
                        Person_ID = c.Int(),
                    })
                .PrimaryKey(t => t.EmailAddressID)
                .ForeignKey("dbo.People", t => t.Person_ID)
                .Index(t => t.Person_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailAddresses", "Person_ID", "dbo.People");
            DropIndex("dbo.EmailAddresses", new[] { "Person_ID" });
            DropTable("dbo.EmailAddresses");
            DropTable("dbo.People");
        }
    }
}
