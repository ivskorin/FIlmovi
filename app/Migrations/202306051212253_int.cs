namespace app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drzavas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Trajanje = c.Int(nullable: false),
                        ZanrId = c.Int(nullable: false),
                        DrzavaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drzavas", t => t.DrzavaId, cascadeDelete: true)
                .ForeignKey("dbo.Zanrs", t => t.ZanrId, cascadeDelete: true)
                .Index(t => t.ZanrId)
                .Index(t => t.DrzavaId);
            
            CreateTable(
                "dbo.Zanrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "ZanrId", "dbo.Zanrs");
            DropForeignKey("dbo.Films", "DrzavaId", "dbo.Drzavas");
            DropIndex("dbo.Films", new[] { "DrzavaId" });
            DropIndex("dbo.Films", new[] { "ZanrId" });
            DropTable("dbo.Zanrs");
            DropTable("dbo.Films");
            DropTable("dbo.Drzavas");
        }
    }
}
