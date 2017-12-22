namespace Garage25_CodeAlong.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage25_CodeAlong.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage25_CodeAlong.DataAccessLayer.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.VehicleTypes.AddOrUpdate(x => x.TypeName,
                new Models.VehicleType() { TypeName = "Car" },
                     new Models.VehicleType() { TypeName = "Bus" },
                          new Models.VehicleType() { TypeName = "Airplane" },
                               new Models.VehicleType() { TypeName = "Boat" },
                                    new Models.VehicleType() { TypeName = "Motorcycle" });
            context.SaveChanges();

            context.Members.AddOrUpdate(x => x.Email,
                 new Models.Member()
                 {
                     FName = "Bob",
                     LName = "Burger",
                     DateOfBirth = DateTime.Now.AddYears(-200),
                     Address = "BurgerJoint Alley 89",
                     Email = "Bob@Burger.com",
                     PhoneNum = "555-555559"

                 },
            new Models.Member()
            {
                FName = "Belat",
                LName = "Burger",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Address = "BurgerJoint Alley 89",
                Email = "Belate@Burger.com",
                PhoneNum = "555-555559"

            },
             new Models.Member()
             {
                 FName = "Sara",
                 LName = "Slime",
                 DateOfBirth = DateTime.Now.AddYears(-50),
                 Address = "ToambStone road 01",
                 Email = "sara.slime@tomb.rip",
                 PhoneNum = ""

             });

            context.SaveChanges();

            context.ParkedVehicles.AddOrUpdate(x => x.RegNum,
                new Models.ParkedVehicle()
                {
                    RegNum = "FIR001",
                    NoOfWheels = 4,
                    Brand = "volvo",
                    Model = "S80",
                    Color = "Rust",
                    ParkingTime = DateTime.Now.AddHours(-1),
                    Member = context.Members.ToList()[0],            //becoz we have given [required] for member in parked vehicel
                    TypeId=context.VehicleTypes.ToList()[0].Id

                },

                new Models.ParkedVehicle()
                {
                    RegNum = "SEC001",
                    NoOfWheels = 2,
                    Brand = "Kamzaki",
                    Model = "Razor",
                    Color = "Black",
                    ParkingTime = DateTime.Now.AddHours(-9000),
                    Member = context.Members.ToList()[2],
                    TypeId = context.VehicleTypes.ToList()[3].Id

                },
                 new Models.ParkedVehicle()
                 {
                     RegNum = "RSD002",
                     NoOfWheels = 2,
                     Brand = "Kamzaki",
                     Model = "Razor",
                     Color = "Black",
                     ParkingTime = DateTime.Now.AddHours(-5),
                     Member= context.Members.ToList()[1],
                     TypeId = context.VehicleTypes.ToList()[4].Id

                 }


                );





        }
    }
}
