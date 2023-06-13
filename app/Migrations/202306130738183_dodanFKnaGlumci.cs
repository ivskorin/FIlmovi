namespace app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanFKnaGlumci : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "GlumciId", c => c.Int(nullable: true));
            CreateIndex("dbo.Films", "GlumciId");
            AddForeignKey("dbo.Films", "GlumciId", "dbo.Glumcis", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "GlumciId", "dbo.Glumcis");
            DropIndex("dbo.Films", new[] { "GlumciId" });
            DropColumn("dbo.Films", "GlumciId");
        }
    }
}
