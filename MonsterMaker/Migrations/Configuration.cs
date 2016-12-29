namespace MonsterMaker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MonsterMaker.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MonsterMaker.MonsterMakerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MonsterMaker.MonsterMakerContext context)
        {
            Maker Bob = new Maker { UserId = 1, UserName = "Bob" };
            Maker Joe = new Maker { UserId = 2, UserName = "Joe" };

            Body body01 = new Body { BodyId = 1, BodyType = "Tall", ImageURL = "http://localhost:49263/images/body01.png", StatBonus = 1 };
            Head head01 = new Head { HeadId = 1, HeadType = "Round", ImageURL = "http://localhost:49263/images/head01.png", StatBonus = 1 };
            Arm arm01 = new Arm { ArmId = 1, ArmType = "Rectangle", ImageURL = "http://localhost:49263/images/arm01.png", StatBonus = 1 };
            Leg leg01 = new Leg { LegId = 1, LegType = "Thin", ImageURL = "http://localhost:49263/images/leg01.png", StatBonus = 1 };
            Accessory accessory01 = new Accessory { AccessoryId = 1, AccessoryType = "Star", ImageURL = "http://localhost:49263/images/accessory01.png", StatBonus = 2 };

            context.Makers.AddOrUpdate(
                Bob,
                Joe);
                
            context.BodyType.AddOrUpdate(
                body01);
            context.Heads.AddOrUpdate(
                head01);
            context.Arms.AddOrUpdate(
                arm01);
            context.Legs.AddOrUpdate(
                leg01);
            context.Accessory.AddOrUpdate(
                accessory01);




            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
