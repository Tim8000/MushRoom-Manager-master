namespace MushRoom_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Phone", c => c.Byte(nullable: false));
        }
    }
}
