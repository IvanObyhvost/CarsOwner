﻿using System.Data.Entity;
using CarsOwner.DAL.Entites;

namespace CarsOwner.DAL.EF
{
    public class CarOwnerContext: DbContext
    {
        public CarOwnerContext() : base("DbConnection") { }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<DescriptionCarEntity> DescriptionCar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerEntity>()
                .HasMany(c => c.CarEntities)
                .WithMany(s => s.OwnerEntities)
                .Map(t => t.MapLeftKey("IdOwner")
                .MapRightKey("IdCar")
                .ToTable("CarsOwners"));

            modelBuilder.Entity<DescriptionCarEntity>()
                .HasOptional(c => c.Car)
                .WithRequired(s => s.DescriptionCar);

        }
    }
}
