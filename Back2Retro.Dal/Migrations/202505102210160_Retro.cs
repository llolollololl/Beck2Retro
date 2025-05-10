namespace Back2Retro.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Retro : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Format");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Format", c => c.String());
        }
    }
}
