namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sortowanie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BydloModels", "SortDirection");
            DropColumn("dbo.BydloModels", "SortExpression");
        }
        
        public override void Down()
        {

        }
    }
}
