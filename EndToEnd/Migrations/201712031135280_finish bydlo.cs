namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finishbydlo : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DrobTyps");
        }
        
        public override void Down()
        {

            
        }
    }
}
