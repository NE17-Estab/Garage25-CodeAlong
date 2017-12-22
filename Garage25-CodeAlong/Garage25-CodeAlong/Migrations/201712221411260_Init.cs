namespace Garage25_CodeAlong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Email = c.String(),
                        Adress = c.String(),
                        PhoneNr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNr = c.String(),
                        Color = c.String(),
                        Model = c.String(),
                        Brand = c.String(),
                        NrOfWheels = c.Int(nullable: false),
                        ParkingTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TypeId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicles", "TypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.ParkedVehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.ParkedVehicles", new[] { "MemberId" });
            DropIndex("dbo.ParkedVehicles", new[] { "TypeId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.ParkedVehicles");
            DropTable("dbo.Members");
        }
    }
}
