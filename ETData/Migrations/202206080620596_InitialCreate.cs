namespace ETData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Country = c.String(),
                        TravelRating = c.Double(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteName = c.String(nullable: false, maxLength: 25),
                        RouteModeOfTravel = c.String(nullable: false, maxLength: 6),
                        DepartureTime = c.DateTime(nullable: false),
                        TravelTimeMinutes = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        DistanceKM = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                        Agency_Id = c.Int(nullable: false),
                        EndLocation_Id = c.Int(nullable: false),
                        StartingLocation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TravelAgencies", t => t.Agency_Id, cascadeDelete: false)
                .ForeignKey("dbo.Locations", t => t.EndLocation_Id, cascadeDelete: false)
                .ForeignKey("dbo.Locations", t => t.StartingLocation_Id, cascadeDelete: false)
                .Index(t => t.Agency_Id)
                .Index(t => t.EndLocation_Id)
                .Index(t => t.StartingLocation_Id);
            
            CreateTable(
                "dbo.TravelAgencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgencyName = c.String(nullable: false, maxLength: 25),
                        PlanePrice = c.Double(nullable: false),
                        TrainPrice = c.Double(nullable: false),
                        BusPrice = c.Double(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "StartingLocation_Id", "dbo.Locations");
            DropForeignKey("dbo.Routes", "EndLocation_Id", "dbo.Locations");
            DropForeignKey("dbo.Routes", "Agency_Id", "dbo.TravelAgencies");
            DropIndex("dbo.Routes", new[] { "StartingLocation_Id" });
            DropIndex("dbo.Routes", new[] { "EndLocation_Id" });
            DropIndex("dbo.Routes", new[] { "Agency_Id" });
            DropTable("dbo.TravelAgencies");
            DropTable("dbo.Routes");
            DropTable("dbo.Locations");
        }
    }
}
