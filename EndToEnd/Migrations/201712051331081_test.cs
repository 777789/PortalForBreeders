namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BydloModels", "SortDirection", c => c.Int(nullable: false));
            AddColumn("dbo.BydloModels", "SortExpression", c => c.String());
        }
        
        public override void Down()
        {

        }
    }
}
