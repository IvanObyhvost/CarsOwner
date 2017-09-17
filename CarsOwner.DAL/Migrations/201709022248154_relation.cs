namespace CarsOwner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarEntities",
                c => new
                    {
                        IdCar = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        СarMake = c.String(),
                        TypeCar = c.Byte(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YearRelease = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCar);
            
            CreateTable(
                "dbo.DescriptionCarEntities",
                c => new
                    {
                        IdCar = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdCar)
                .ForeignKey("dbo.CarEntities", t => t.IdCar)
                .Index(t => t.IdCar);
            
            CreateTable(
                "dbo.OwnerEntities",
                c => new
                    {
                        IdOwner = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.Int(nullable: false),
                        DrivingExperience = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdOwner);
            
            CreateTable(
                "dbo.CarsOwners",
                c => new
                    {
                        IdOwner = c.Int(nullable: false),
                        IdCar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdOwner, t.IdCar })
                .ForeignKey("dbo.OwnerEntities", t => t.IdOwner, cascadeDelete: true)
                .ForeignKey("dbo.CarEntities", t => t.IdCar, cascadeDelete: true)
                .Index(t => t.IdOwner)
                .Index(t => t.IdCar);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarsOwners", "IdCar", "dbo.CarEntities");
            DropForeignKey("dbo.CarsOwners", "IdOwner", "dbo.OwnerEntities");
            DropForeignKey("dbo.DescriptionCarEntities", "IdCar", "dbo.CarEntities");
            DropIndex("dbo.CarsOwners", new[] { "IdCar" });
            DropIndex("dbo.CarsOwners", new[] { "IdOwner" });
            DropIndex("dbo.DescriptionCarEntities", new[] { "IdCar" });
            DropTable("dbo.CarsOwners");
            DropTable("dbo.OwnerEntities");
            DropTable("dbo.DescriptionCarEntities");
            DropTable("dbo.CarEntities");
        }
    }
}
