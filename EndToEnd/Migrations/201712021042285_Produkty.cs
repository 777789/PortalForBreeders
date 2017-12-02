namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produkty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BydloModels", "Laktoza");
        }
        
        public override void Down()
        {

        }
    }
}
