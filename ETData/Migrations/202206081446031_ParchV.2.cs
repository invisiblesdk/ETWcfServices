namespace ETData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParchV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TravelAgencies", "OtherPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Routes", "DepartureTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "DepartureTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.TravelAgencies", "OtherPrice");
        }
    }
}
