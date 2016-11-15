namespace MyTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUniqueKeyTracking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arrive",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Location = c.Geography(nullable: false),
                        IdPackage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Package", t => t.IdPackage)
                .Index(t => t.IdPackage);
            
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingNo = c.String(nullable: false, maxLength: 10),
                        Weight = c.Short(nullable: false),
                        InTransit = c.Boolean(nullable: false),
                        Owner = c.String(nullable: false),
                        Destination = c.Geography(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TrackingNo, unique: true, name: "TrackingNoIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arrive", "IdPackage", "dbo.Package");
            DropIndex("dbo.Package", "TrackingNoIndex");
            DropIndex("dbo.Arrive", new[] { "IdPackage" });
            DropTable("dbo.Package");
            DropTable("dbo.Arrive");
        }
    }
}
