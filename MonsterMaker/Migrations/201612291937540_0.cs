namespace MonsterMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0 : DbMigration
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
                        BodyId = c.Int(nullable: false),
                        HeadId = c.Int(nullable: false),
                        ArmId = c.Int(nullable: false),
                        LegId = c.Int(nullable: false),
                        AccessoryId = c.Int(nullable: false),
                        canvasData = c.String(),
                        MakerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonsterId)
                .ForeignKey("dbo.Accessories", t => t.AccessoryId, cascadeDelete: true)
                .ForeignKey("dbo.Arms", t => t.ArmId, cascadeDelete: true)
                .ForeignKey("dbo.Bodies", t => t.BodyId, cascadeDelete: true)
                .ForeignKey("dbo.Heads", t => t.HeadId, cascadeDelete: true)
                .ForeignKey("dbo.Legs", t => t.LegId, cascadeDelete: true)
                .ForeignKey("dbo.Makers", t => t.MakerId, cascadeDelete: true)
                .Index(t => t.BodyId)
                .Index(t => t.HeadId)
                .Index(t => t.ArmId)
                .Index(t => t.LegId)
                .Index(t => t.AccessoryId)
                .Index(t => t.MakerId);
            
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
            DropForeignKey("dbo.Monsters", "MakerId", "dbo.Makers");
            DropForeignKey("dbo.Monsters", "LegId", "dbo.Legs");
            DropForeignKey("dbo.Monsters", "HeadId", "dbo.Heads");
            DropForeignKey("dbo.Monsters", "BodyId", "dbo.Bodies");
            DropForeignKey("dbo.Monsters", "ArmId", "dbo.Arms");
            DropForeignKey("dbo.Monsters", "AccessoryId", "dbo.Accessories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Monsters", new[] { "MakerId" });
            DropIndex("dbo.Monsters", new[] { "AccessoryId" });
            DropIndex("dbo.Monsters", new[] { "LegId" });
            DropIndex("dbo.Monsters", new[] { "ArmId" });
            DropIndex("dbo.Monsters", new[] { "HeadId" });
            DropIndex("dbo.Monsters", new[] { "BodyId" });
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
