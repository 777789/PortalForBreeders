namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produkty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bialko_ogolne = c.Single(nullable: false),
                        Energia = c.Single(nullable: false),
                        Oleje_i_tluszcze = c.Single(nullable: false),
                        wlokno_surowe = c.Single(nullable: false),
                        popiol_surowy = c.Single(nullable: false),
                        wapn = c.Single(nullable: false),
                        fosfor_przyswajalny = c.Single(nullable: false),
                        sod = c.Single(nullable: false),
                        lizyna = c.Single(nullable: false),
                        metionina = c.Single(nullable: false),
                        treonina = c.Single(nullable: false),
                        tryptofan = c.Single(nullable: false),
                        witamina_a = c.Single(nullable: false),
                        witamina_d3 = c.Single(nullable: false),
                        witamina_e = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {

        }
    }
}
