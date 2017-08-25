using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsOwner.DAL.Entites;

namespace CarsOwner.DAL.EF
{
    public class CarOwnerContext: DbContext
    {
        public CarOwnerContext() : base("DbConnection") { }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerEntity>().HasMany(c => c.CarEntities)
                .WithMany(s => s.OwnerEntities)
                .Map(t => t.MapLeftKey("IdOwner")
                .MapRightKey("IdCar")
                .ToTable("CarsOwners"));
        }
    }
}
