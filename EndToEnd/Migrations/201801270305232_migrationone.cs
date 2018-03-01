namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
          "dbo.IndykModels",
          c => new
          {
              Id = c.Int(nullable: false, identity: true),
              Wiek = c.String(),
              Pasza = c.String(),
              Producent = c.String(),
              Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
              Bialko = c.Decimal(nullable: false, precision: 18, scale: 2),
              Energia = c.Decimal(nullable: false, precision: 18, scale: 2),
              Oleje = c.Decimal(nullable: false, precision: 18, scale: 2),
              Wapn = c.Decimal(nullable: false, precision: 18, scale: 2),
              Fosfor = c.Decimal(nullable: false, precision: 18, scale: 2),
              Sod = c.Decimal(nullable: false, precision: 18, scale: 2),
              Lizyna = c.Decimal(nullable: false, precision: 18, scale: 2),
              Metionina = c.Decimal(nullable: false, precision: 18, scale: 2),
              Treonina = c.Decimal(nullable: false, precision: 18, scale: 2),
          })
          .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.GesModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Wiek = c.String(),
                    Pasza = c.String(),
                    Producent = c.String(),
                    Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Bialko = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Energia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Oleje = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Wapn = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Fosfor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Sod = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Lizyna = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Metionina = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Treonina = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.KaczkaModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Wiek = c.String(),
                    Pasza = c.String(),
                    Producent = c.String(),
                    Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Bialko = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Energia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Oleje = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Wapn = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Fosfor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Sod = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Lizyna = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Metionina = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Treonina = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.KuraModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Wiek = c.String(),
                    Pasza = c.String(),
                    Producent = c.String(),
                    Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Bialko = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Energia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Oleje = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Wapn = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Fosfor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Sod = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Lizyna = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Metionina = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Treonina = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
               "dbo.TrzodaModels",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Wiek = c.String(),
                   Pasza = c.String(),
                   Producent = c.String(),
                   Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Bialko = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Energia = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Tluszcze = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Wapn = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Fosfor = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Sod = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Magnez = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Lizyna = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Metionina = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Treonina = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Arginina = c.Decimal(nullable: false, precision: 18, scale: 2),
               })
               .PrimaryKey(t => t.Id);

            CreateTable(
               "dbo.BydloModels",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   Wiek = c.String(),
                   Pasza = c.String(),
                   Producent = c.String(),
                   Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Bialko = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Energia = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Tluszcze = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Wapn = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Fosfor = c.Decimal(nullable: false, precision: 18, scale: 2),
                   Sod = c.Decimal(nullable: false, precision: 18, scale: 2),
               })
               .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {

        }
    }
}
