namespace CarsOwner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableDescriptionCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DescriptionCarEntities",
                c => new
                    {
                        IdCar = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdCar);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DescriptionCarEntities");
        }
    }
}
