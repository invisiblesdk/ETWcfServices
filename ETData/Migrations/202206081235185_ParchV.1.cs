namespace ETData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParchV1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Routes", name: "Agency_Id", newName: "AgencyId");
            RenameColumn(table: "dbo.Routes", name: "EndLocation_Id", newName: "EndLocationId");
            RenameColumn(table: "dbo.Routes", name: "StartingLocation_Id", newName: "StartingLocationId");
            RenameIndex(table: "dbo.Routes", name: "IX_Agency_Id", newName: "IX_AgencyId");
            RenameIndex(table: "dbo.Routes", name: "IX_StartingLocation_Id", newName: "IX_StartingLocationId");
            RenameIndex(table: "dbo.Routes", name: "IX_EndLocation_Id", newName: "IX_EndLocationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Routes", name: "IX_EndLocationId", newName: "IX_EndLocation_Id");
            RenameIndex(table: "dbo.Routes", name: "IX_StartingLocationId", newName: "IX_StartingLocation_Id");
            RenameIndex(table: "dbo.Routes", name: "IX_AgencyId", newName: "IX_Agency_Id");
            RenameColumn(table: "dbo.Routes", name: "StartingLocationId", newName: "StartingLocation_Id");
            RenameColumn(table: "dbo.Routes", name: "EndLocationId", newName: "EndLocation_Id");
            RenameColumn(table: "dbo.Routes", name: "AgencyId", newName: "Agency_Id");
        }
    }
}
