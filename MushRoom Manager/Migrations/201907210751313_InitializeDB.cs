namespace MushRoom_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Phone = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MushroomTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        PackageWeight = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        MushroomTypeId = c.Byte(nullable: false),
                        Amount = c.Byte(nullable: false),
                        Price = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MushroomTypes", t => t.MushroomTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.MushroomTypeId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        RequestStatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.RequestStatus", t => t.RequestStatusId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.RequestStatusId);
            
            CreateTable(
                "dbo.RequestStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RequestItems", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Requests", "RequestStatusId", "dbo.RequestStatus");
            DropForeignKey("dbo.Requests", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.RequestItems", "MushroomTypeId", "dbo.MushroomTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Requests", new[] { "RequestStatusId" });
            DropIndex("dbo.Requests", new[] { "ClientId" });
            DropIndex("dbo.RequestItems", new[] { "MushroomTypeId" });
            DropIndex("dbo.RequestItems", new[] { "RequestId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RequestStatus");
            DropTable("dbo.Requests");
            DropTable("dbo.RequestItems");
            DropTable("dbo.MushroomTypes");
            DropTable("dbo.Clients");
        }
    }
}
