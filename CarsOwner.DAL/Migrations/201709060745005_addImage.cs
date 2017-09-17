namespace CarsOwner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DescriptionCarEntities", "ImageData", c => c.Binary());
            AddColumn("dbo.DescriptionCarEntities", "ImageMineType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DescriptionCarEntities", "ImageMineType");
            DropColumn("dbo.DescriptionCarEntities", "ImageData");
        }
    }
}
