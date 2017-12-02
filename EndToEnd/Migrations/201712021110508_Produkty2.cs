namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produkty2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TrzodaModels", "Wlokno_surowe");
            DropColumn("dbo.TrzodaModels", "Popiol_surowy");
        }
        
        public override void Down()
        {

        }
    }
}
