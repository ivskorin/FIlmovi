namespace app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class korisnikDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 100),
                        Prezime = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        LoginErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Korisniks");
        }
    }
}
