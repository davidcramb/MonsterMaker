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

            Body body01 = new Body { BodyId = 1, BodyType = "Rectangle", ImageURL = "http://localhost:49263/images/body_01.png", StatBonus = 1 };
            Body body02 = new Body { BodyId = 2, BodyType = "Frank", ImageURL = "http://localhost:49263/images/body_02.png", StatBonus = 1 };
            Body body03 = new Body { BodyId = 3, BodyType = "Lagoon", ImageURL = "http://localhost:49263/images/body_03.png", StatBonus = 1 };
            Body body04 = new Body { BodyId = 4, BodyType = "Werewolf", ImageURL = "http://localhost:49263/images/body_04.png", StatBonus = 1 };

            Head head01 = new Head { HeadId = 1, HeadType = "Circle", ImageURL = "http://localhost:49263/images/head_01.png", StatBonus = 1 };
            Head head02 = new Head { HeadId = 2, HeadType = "Frank", ImageURL = "http://localhost:49263/images/head_02.png", StatBonus = 1 };
            Head head03 = new Head { HeadId = 3, HeadType = "Werewolf", ImageURL = "http://localhost:49263/images/head_03.png", StatBonus = 1 };

            Arm arm01 = new Arm { ArmId = 1, ArmType = "Rectangle", ImageURL = "http://localhost:49263/images/arm_01.png", StatBonus = 1 };

            Leg leg01 = new Leg { LegId = 1, LegType = "Thin", ImageURL = "http://localhost:49263/images/leg_01.png", StatBonus = 1 };
            Leg leg02 = new Leg { LegId = 2, LegType = "Bones", ImageURL = "http://localhost:49263/images/leg_02.png", StatBonus = 1 };
            Leg leg03 = new Leg { LegId = 3, LegType = "Frank", ImageURL = "http://localhost:49263/images/leg_03.png", StatBonus = 1 };
            Leg leg04 = new Leg { LegId = 4, LegType = "Drumstick", ImageURL = "http://localhost:49263/images/leg_04.png", StatBonus = 1 };
            Leg leg05 = new Leg { LegId = 5, LegType = "Robot", ImageURL = "http://localhost:49263/images/leg_05.png", StatBonus = 1 };
            Leg leg06 = new Leg { LegId = 6, LegType = "Zombie", ImageURL = "http://localhost:49263/images/leg_06.png", StatBonus = 1 };

            Accessory accessory01 = new Accessory { AccessoryId = 1, AccessoryType = "Star", ImageURL = "http://localhost:49263/images/accessory_01.png", StatBonus = 2 };

            context.Makers.AddOrUpdate(
                Bob,
                Joe);
                
            context.BodyType.AddOrUpdate(
                body01, body02, body03, body04);
            context.Heads.AddOrUpdate(
                head01, head02, head03);
            context.Arms.AddOrUpdate(
                arm01);
            context.Legs.AddOrUpdate(
                leg01, leg02, leg03, leg04, leg05, leg06);
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
