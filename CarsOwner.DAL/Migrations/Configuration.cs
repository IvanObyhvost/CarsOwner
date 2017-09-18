using CarsOwner.DAL.Entites;

namespace CarsOwner.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsOwner.DAL.EF.CarOwnerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarsOwner.DAL.EF.CarOwnerContext context)
        {
            //context.Owners.AddOrUpdate(
            //        new OwnerEntity
            //        {
            //            IdOwner = 1,
            //            Name = "Иван", 
            //            Surname = "Обыхвост",
            //            BirthDate = 1993,
            //            DrivingExperience = 2,
            //        },
            //        new OwnerEntity
            //        {
            //            IdOwner = 2,
            //            Name = "Алена",
            //            Surname = "Орлова",
            //            BirthDate = 1994,
            //            DrivingExperience = 1,
            //        }
            //    );
        }
    }
}
