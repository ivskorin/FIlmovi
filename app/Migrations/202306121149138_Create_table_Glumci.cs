namespace app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_table_Glumci : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Glumcis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Glumcis");
        }
    }
}
