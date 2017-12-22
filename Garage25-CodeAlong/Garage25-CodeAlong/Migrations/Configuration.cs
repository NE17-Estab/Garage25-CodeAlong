namespace Garage25_CodeAlong.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage25_CodeAlong.DataAccess.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage25_CodeAlong.DataAccess.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.VehicleTypes.AddOrUpdate(x => x.TypeName, 
                new Models.VehicleType() { TypeName = "Car" },
                new Models.VehicleType() { TypeName = "Bus" },
                new Models.VehicleType() { TypeName = "Airplane" },
                new Models.VehicleType() { TypeName = "Boat" },
                new Models.VehicleType() { TypeName = "Motorcycle" })
                ;
            context.SaveChanges();
            context.Members.AddOrUpdate(x => x.Email,
                new Models.Member()
                {
                    FName ="Bob",
                    LName="Burger",
                    DateOfBirth = DateTime.Now.AddYears(-50),
                    Adress = "BurgerJoint Ally 89",
                    Email = "Bob@Burger.com",
                    PhoneNr = "555-555559"
                }, new Models.Member()
                {
                    FName = "Belat",
                    LName = "Burger",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    Adress = "BurgerJoint Ally 89",
                    Email = "Belat@Burger.com",
                    PhoneNr = "555-555559"
                }, new Models.Member()
                {
                    FName = "Sara",
                    LName = "Slime",
                    DateOfBirth = DateTime.Now.AddYears(-200),
                    Adress = "Tombestone Road 01",
                    Email = "Sara.Slime@tomb.rip",
                    PhoneNr = ""
                });
            context.SaveChanges();
            context.ParkedVehicles.AddOrUpdate(x => x.RegNr,
                new Models.ParkedVehicle()
                {
                    RegNr = "FIR001",
                    NrOfWheels = 4,
                    Brand = "Volvo",
                    Model = "S80",
                    Color = "Rust",
                    ParkingTime = DateTime.Now.AddHours(-1),
                    Member = context.Members.ToList()[0],
                    TypeId = context.VehicleTypes.ToList()[0].Id
                }, new Models.ParkedVehicle()
                {
                    RegNr = "ARK000",
                    NrOfWheels = 0,
                    Brand = "ARK",
                    Model = "Noah",
                    Color = "Wood",
                    ParkingTime = DateTime.Now.AddHours(-90000),
                    Member = context.Members.ToList()[2],
                    TypeId = context.VehicleTypes.ToList()[3].Id
                }, new Models.ParkedVehicle()
                {
                    RegNr = "SEC002",
                    NrOfWheels = 2,
                    Brand = "Kamzaki",
                    Model = "Razor",
                    Color = "Black",
                    ParkingTime = DateTime.Now.AddHours(-5),
                    Member = context.Members.ToList()[1],
                    TypeId = context.VehicleTypes.ToList()[4].Id
                }
                );

        }
    }
}
