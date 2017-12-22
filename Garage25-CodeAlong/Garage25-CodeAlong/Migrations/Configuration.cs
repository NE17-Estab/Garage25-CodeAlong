namespace Garage25_CodeAlong.Migrations
{
    using Models;
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
                new VehicleType() { TypeName = "Car" },
                new VehicleType() { TypeName = "Bus" },
                new VehicleType() { TypeName = "Airplane" },
                new VehicleType() { TypeName = "Boat" },
                new VehicleType() { TypeName = "Motorcycle" });
            context.SaveChanges();
            context.Members.AddOrUpdate(x => x.Email,
                new Member() {
                FName = "Bob",
                LName="Burger",
                DateOfBirth = DateTime.Now.AddYears(-15),
                Adress="BurgerJoin",
                Email="bob@me.com",
                PhoneNr="555-254697"},
                new Member(){
                FName = "Sara",
                LName = "Burger",
                DateOfBirth = DateTime.Now.AddYears(-10),
                Adress = "Un",
                Email = "sara@me.com",
                PhoneNr = "555-200697"},
                new Member(){
                FName = "Bob",
                LName = "Burger",
                DateOfBirth = DateTime.Now.AddYears(-5),
                Adress = "BurgerJoin",
                Email = "bob@me.com",
                PhoneNr = "555-254697"});

                context.SaveChanges();

            context.ParkedVehicles.AddOrUpdate(x => x.RegNr,
                new ParkedVehicle()
                {
                    RegNr = "ABC123",
                    NrOfWheels = 4,
                    Brand = "Volvo",
                    Model = "s80",
                    Color = "Rust",
                    ParkingTime = DateTime.Now.AddHours(-1),
                    MemberId = context.Members.ToList()[0].Id,
                    TypeId = context.VehicleTypes.ToList()[0].Id
                },
               new ParkedVehicle()
               {
                   RegNr = "ABB123",
                   NrOfWheels = 2,
                   Brand = "Kawasaki",
                   Model = "Razor",
                   Color = "Bluck",
                   ParkingTime = DateTime.Now.AddHours(-5),
                   MemberId = context.Members.ToList()[2].Id,
                   TypeId = context.VehicleTypes.ToList()[4].Id
               },
               new ParkedVehicle()
               {
                   RegNr = "ABC123",
                   NrOfWheels = 0,
                   Brand = "Ark",
                   Model = "Noa",
                   Color = "Pink",
                   ParkingTime = DateTime.Now.AddHours(-9),
                   MemberId = context.Members.ToList()[2].Id,
                   TypeId = context.VehicleTypes.ToList()[3].Id
               });
            context.SaveChanges();
        }
    }
}
