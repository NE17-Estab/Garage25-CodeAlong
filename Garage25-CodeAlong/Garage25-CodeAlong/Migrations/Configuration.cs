namespace Garage25_CodeAlong.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
  //using Garage25_CodeAlong.Models;

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
            context.VehicleTypes.AddOrUpdate(x => x.TypeName, new Models.VehicleType() { TypeName = "Car" },
                new Models.VehicleType() { TypeName = "Bus" },
                new Models.VehicleType() { TypeName = "Airplane" },
                new Models.VehicleType() { TypeName = "Boat" },
                new Models.VehicleType() { TypeName = "MotorCycle" });
            context.SaveChanges();

            context.Members.AddOrUpdate(x => x.Email, new Models.Member()
            {
                FName = "Bob",
                LName = "Burger",
                DateOfBirth = DateTime.Now.AddYears(-50),
                Adress = "BurgerJoint Ally 89",
                Email = "Bob@Burger.com",
                PhoneNr = "555-55555"
            }, new Models.Member() {
                FName = "Bob",
                LName = "Burger",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Adress = "BurgerJoit Ally 9",
                Email = "Bob@Burger.com",
                PhoneNr = "555-55555"

            }, new Models.Member()
            {

                FName = "Bob",
                LName = "Burger",
                DateOfBirth = DateTime.Now.AddYears(-200),
                Adress = "Burgeroint Ally 9",
                Email = "Bob@Burger.com",
                PhoneNr = "555-55555"
                });

            context.SaveChanges();
            context.ParkedVehicles.AddOrUpdate(x => x.RegNr, new Models.ParkedVehicle()
            {
                RegNr = "FIR001",
                NrOfWheels = 4,
                Brand = "Volvo",
                Model = "S80",
                Color = "Rust",
                ParkingTime = DateTime.Now.AddHours(-1),
                MemberId = context.Members.ToList()[0].Id,
                TypeId = context.VehicleTypes.ToList()[0].Id
            }, new Models.ParkedVehicle()
            {

                RegNr = "SEC001",
                NrOfWheels = 4,
                Brand = "Volvo",
                Model = "S80",
                Color = "wood",
                ParkingTime = DateTime.Now.AddHours(-9000),
                MemberId = context.Members.ToList()[2].Id,
                TypeId = context.VehicleTypes.ToList()[3].Id

            }
            , new Models.ParkedVehicle()
            {

                RegNr = "SEC001",
                NrOfWheels = 4,
                Brand = "Volvo",
                Model = "S80",
                Color = "wood",
                ParkingTime = DateTime.Now.AddHours(-5),
                MemberId= context.Members.ToList()[1].Id,
                
                TypeId = context.VehicleTypes.ToList()[4].Id

            });


            context.SaveChanges();





        }
    }
}
