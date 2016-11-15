namespace MyTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameArrive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arrive", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Arrive", "Name");
        }
    }
}
