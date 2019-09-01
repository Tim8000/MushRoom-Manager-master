namespace MushRoom_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTheMushRooms : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MushroomTypes (Id, Name, PackageWeight) VALUES (1, 'Small', 10)");
            Sql("INSERT INTO MushroomTypes (Id, Name, PackageWeight) VALUES (2, 'Standard', 20)");
            Sql("INSERT INTO MushroomTypes (Id, Name, PackageWeight) VALUES (3, 'Deviant', 30)");
            Sql("INSERT INTO MushroomTypes (Id, Name, PackageWeight) VALUES (4,'HighestQuality', 40)");
        }
        
        public override void Down()
        {
        }
    }
}
