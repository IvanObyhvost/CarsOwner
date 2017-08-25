namespace CarsOwner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarEntities", "TypeCar", c => c.Byte(nullable: false));
            AlterColumn("dbo.CarEntities", "YearRelease", c => c.Int(nullable: false));
            AlterColumn("dbo.OwnerEntities", "BirthDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OwnerEntities", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CarEntities", "YearRelease", c => c.DateTime(nullable: false));
            DropColumn("dbo.CarEntities", "TypeCar");
        }
    }
}
