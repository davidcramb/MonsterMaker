namespace MonsterMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                        AccessoryType = c.String(),
                        ImageURL = c.String(),
                        StatBonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoryId);
            
            CreateTable(
                "dbo.Arms",
                c => new
                    {
                        ArmId = c.Int(nullable: false, identity: true),
                        ArmType = c.String(),
                        ImageURL = c.String(),
                        StatBonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArmId);
            
            CreateTable(
                "dbo.BattleLogs",
                c => new
                    {
                        BattleId = c.Int(nullable: false, identity: true),
                        Monster1_MonsterId = c.Int(),
                        Monster2_MonsterId = c.Int(),
                        User1_UserId = c.Int(),
                        User2_UserId = c.Int(),
                        Winner_MonsterId = c.Int(),
                    })
                .PrimaryKey(t => t.BattleId)
                .ForeignKey("dbo.Monsters", t => t.Monster1_MonsterId)
                .ForeignKey("dbo.Monsters", t => t.Monster2_MonsterId)
                .ForeignKey("dbo.Makers", t => t.User1_UserId)
                .ForeignKey("dbo.Makers", t => t.User2_UserId)
                .ForeignKey("dbo.Monsters", t => t.Winner_MonsterId)
                .Index(t => t.Monster1_MonsterId)
                .Index(t => t.Monster2_MonsterId)
                .Index(t => t.User1_UserId)
                .Index(t => t.User2_UserId)
                .Index(t => t.Winner_MonsterId);
            
            CreateTable(
                "dbo.Monsters",
                c => new
                    {
                        MonsterId = c.Int(nullable: false, identity: true),
                        MonsterName = c.String(nullable: false),
                        AccessoryId_AccessoryId = c.Int(),
                        AccessoryType_AccessoryId = c.Int(),
                        ArmId_ArmId = c.Int(),
                        ArmType_ArmId = c.Int(),
                        BodyId_BodyId = c.Int(),
                        BodyType_BodyId = c.Int(),
                        HeadId_HeadId = c.Int(),
                        HeadType_HeadId = c.Int(),
                        LegId_LegId = c.Int(),
                        LegType_LegId = c.Int(),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MonsterId)
                .ForeignKey("dbo.Accessories", t => t.AccessoryId_AccessoryId)
                .ForeignKey("dbo.Accessories", t => t.AccessoryType_AccessoryId)
                .ForeignKey("dbo.Arms", t => t.ArmId_ArmId)
                .ForeignKey("dbo.Arms", t => t.ArmType_ArmId)
                .ForeignKey("dbo.Bodies", t => t.BodyId_BodyId)
                .ForeignKey("dbo.Bodies", t => t.BodyType_BodyId)
                .ForeignKey("dbo.Heads", t => t.HeadId_HeadId)
                .ForeignKey("dbo.Heads", t => t.HeadType_HeadId)
                .ForeignKey("dbo.Legs", t => t.LegId_LegId)
                .ForeignKey("dbo.Legs", t => t.LegType_LegId)
                .ForeignKey("dbo.Makers", t => t.UserId_UserId)
                .Index(t => t.AccessoryId_AccessoryId)
                .Index(t => t.AccessoryType_AccessoryId)
                .Index(t => t.ArmId_ArmId)
                .Index(t => t.ArmType_ArmId)
                .Index(t => t.BodyId_BodyId)
                .Index(t => t.BodyType_BodyId)
                .Index(t => t.HeadId_HeadId)
                .Index(t => t.HeadType_HeadId)
                .Index(t => t.LegId_LegId)
                .Index(t => t.LegType_LegId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        BodyId = c.Int(nullable: false, identity: true),
                        BodyType = c.String(),
                        ImageURL = c.String(),
                        StatBonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BodyId);
            
            CreateTable(
                "dbo.Heads",
                c => new
                    {
                        HeadId = c.Int(nullable: false, identity: true),
                        HeadType = c.String(),
                        ImageURL = c.String(),
                        StatBonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadId);
            
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        LegId = c.Int(nullable: false, identity: true),
                        LegType = c.String(),
                        ImageURL = c.String(),
                        StatBonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LegId);
            
            CreateTable(
                "dbo.Makers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
            DropForeignKey("dbo.BattleLogs", "Winner_MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.BattleLogs", "User2_UserId", "dbo.Makers");
            DropForeignKey("dbo.BattleLogs", "User1_UserId", "dbo.Makers");
            DropForeignKey("dbo.BattleLogs", "Monster2_MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.BattleLogs", "Monster1_MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.Monsters", "UserId_UserId", "dbo.Makers");
            DropForeignKey("dbo.Monsters", "LegType_LegId", "dbo.Legs");
            DropForeignKey("dbo.Monsters", "LegId_LegId", "dbo.Legs");
            DropForeignKey("dbo.Monsters", "HeadType_HeadId", "dbo.Heads");
            DropForeignKey("dbo.Monsters", "HeadId_HeadId", "dbo.Heads");
            DropForeignKey("dbo.Monsters", "BodyType_BodyId", "dbo.Bodies");
            DropForeignKey("dbo.Monsters", "BodyId_BodyId", "dbo.Bodies");
            DropForeignKey("dbo.Monsters", "ArmType_ArmId", "dbo.Arms");
            DropForeignKey("dbo.Monsters", "ArmId_ArmId", "dbo.Arms");
            DropForeignKey("dbo.Monsters", "AccessoryType_AccessoryId", "dbo.Accessories");
            DropForeignKey("dbo.Monsters", "AccessoryId_AccessoryId", "dbo.Accessories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Monsters", new[] { "UserId_UserId" });
            DropIndex("dbo.Monsters", new[] { "LegType_LegId" });
            DropIndex("dbo.Monsters", new[] { "LegId_LegId" });
            DropIndex("dbo.Monsters", new[] { "HeadType_HeadId" });
            DropIndex("dbo.Monsters", new[] { "HeadId_HeadId" });
            DropIndex("dbo.Monsters", new[] { "BodyType_BodyId" });
            DropIndex("dbo.Monsters", new[] { "BodyId_BodyId" });
            DropIndex("dbo.Monsters", new[] { "ArmType_ArmId" });
            DropIndex("dbo.Monsters", new[] { "ArmId_ArmId" });
            DropIndex("dbo.Monsters", new[] { "AccessoryType_AccessoryId" });
            DropIndex("dbo.Monsters", new[] { "AccessoryId_AccessoryId" });
            DropIndex("dbo.BattleLogs", new[] { "Winner_MonsterId" });
            DropIndex("dbo.BattleLogs", new[] { "User2_UserId" });
            DropIndex("dbo.BattleLogs", new[] { "User1_UserId" });
            DropIndex("dbo.BattleLogs", new[] { "Monster2_MonsterId" });
            DropIndex("dbo.BattleLogs", new[] { "Monster1_MonsterId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Makers");
            DropTable("dbo.Legs");
            DropTable("dbo.Heads");
            DropTable("dbo.Bodies");
            DropTable("dbo.Monsters");
            DropTable("dbo.BattleLogs");
            DropTable("dbo.Arms");
            DropTable("dbo.Accessories");
        }
    }
}
