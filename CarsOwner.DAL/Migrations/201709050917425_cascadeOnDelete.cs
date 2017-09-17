namespace CarsOwner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadeOnDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DescriptionCarEntities", "IdCar", "dbo.CarEntities");
            AddForeignKey("dbo.DescriptionCarEntities", "IdCar", "dbo.CarEntities", "IdCar", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DescriptionCarEntities", "IdCar", "dbo.CarEntities");
            AddForeignKey("dbo.DescriptionCarEntities", "IdCar", "dbo.CarEntities", "IdCar");
        }
    }
}
