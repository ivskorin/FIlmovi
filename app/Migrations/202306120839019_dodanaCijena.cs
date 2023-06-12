namespace app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanaCijena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Cijena", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Cijena");
        }
    }
}
