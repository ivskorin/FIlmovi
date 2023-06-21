namespace app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rolas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Korisniks", "RolaId", c => c.Int(nullable: true));
            CreateIndex("dbo.Korisniks", "RolaId");
            AddForeignKey("dbo.Korisniks", "RolaId", "dbo.Rolas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Korisniks", "RolaId", "dbo.Rolas");
            DropIndex("dbo.Korisniks", new[] { "RolaId" });
            DropColumn("dbo.Korisniks", "RolaId");
            DropTable("dbo.Rolas");
        }
    }
}
