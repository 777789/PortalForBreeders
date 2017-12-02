namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produkty3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BydloModels", "Typ", c => c.String());
            AddColumn("dbo.BydloModels", "Bialko", c => c.Single(nullable: false));
            AlterColumn("dbo.BydloModels", "Cena", c => c.Single(nullable: false));
            AlterColumn("dbo.BydloModels", "Energia", c => c.Single(nullable: false));
            AlterColumn("dbo.BydloModels", "Oleje_I_Tluszcze", c => c.Single(nullable: false));
            AlterColumn("dbo.BydloModels", "Wapn", c => c.Single(nullable: false));
            AlterColumn("dbo.BydloModels", "Fosfor", c => c.Single(nullable: false));
            AlterColumn("dbo.BydloModels", "Sod", c => c.Single(nullable: false));
            DropColumn("dbo.BydloModels", "Bialko_Ogolne");
        }
        
        public override void Down()
        {

        }
    }
}
