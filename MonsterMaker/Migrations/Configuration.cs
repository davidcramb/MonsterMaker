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
      
            Body body01 = new Body { BodyId = 1, BodyType = "Rectangle", ImageURL = "http://localhost:49263/images/body_01.png", StatBonus = 1 };
            Body body02 = new Body { BodyId = 2, BodyType = "Frank", ImageURL = "http://localhost:49263/images/body_02.png", StatBonus = 1 };
            Body body03 = new Body { BodyId = 3, BodyType = "Lagoon", ImageURL = "http://localhost:49263/images/body_03.png", StatBonus = 1 };
            Body body04 = new Body { BodyId = 4, BodyType = "Werewolf", ImageURL = "http://localhost:49263/images/body_04.png", StatBonus = 1 };
            Body body05 = new Body { BodyId = 5, BodyType = "Spaceman", ImageURL = "http://localhost:49263/images/body_05.png", StatBonus = 1 };
            Head head01 = new Head { HeadId = 1, HeadType = "Circle", ImageURL = "http://localhost:49263/images/head_01.png", StatBonus = 1 };
            Head head02 = new Head { HeadId = 2, HeadType = "Frank", ImageURL = "http://localhost:49263/images/head_02.png", StatBonus = 1 };
            Head head03 = new Head { HeadId = 3, HeadType = "Werewolf", ImageURL = "http://localhost:49263/images/head_03.png", StatBonus = 1 };
            Head head04 = new Head { HeadId = 4, HeadType = "Demon", ImageURL = "http://localhost:49263/images/head_04.png", StatBonus = 1 };
            Head head05 = new Head { HeadId = 5, HeadType = "StonedAlien", ImageURL = "http://localhost:49263/images/head_05.png", StatBonus = 1 };
            Head head06 = new Head { HeadId = 6, HeadType = "Birdman", ImageURL = "http://localhost:49263/images/head_06.png", StatBonus = 1 };
            Head head07 = new Head { HeadId = 7, HeadType = "Lagoon", ImageURL = "http://localhost:49263/images/head_07.png", StatBonus = 1 };
            Head head08 = new Head { HeadId = 8, HeadType = "Robot", ImageURL = "http://localhost:49263/images/head_08.png", StatBonus = 1 };
            Head head09 = new Head { HeadId = 9, HeadType = "MeanET", ImageURL = "http://localhost:49263/images/head_09.png", StatBonus = 1 };
            Head head10 = new Head { HeadId = 10, HeadType = "Spaceman", ImageURL = "http://localhost:49263/images/head_10.png", StatBonus = 1 };
            Head head11 = new Head { HeadId = 11, HeadType = "Robot", ImageURL = "http://localhost:49263/images/head_11.png", StatBonus = 1 };
            Head head12 = new Head { HeadId = 12, HeadType = "Doyle", ImageURL = "http://localhost:49263/images/head_12.png", StatBonus = 1 };
            Arm arm01 = new Arm { ArmId = 1, ArmType = "Rectangle", ImageURL = "http://localhost:49263/images/arm_01.png", StatBonus = 1 };
            Arm arm02 = new Arm { ArmId = 2, ArmType = "Tentacle", ImageURL = "http://localhost:49263/images/arm_02.png", StatBonus = 1 };
            Arm arm03 = new Arm { ArmId = 3, ArmType = "Werewolf", ImageURL = "http://localhost:49263/images/arm_03.png", StatBonus = 1 };
            Arm arm04 = new Arm { ArmId = 4, ArmType = "Robot", ImageURL = "http://localhost:49263/images/arm_04.png", StatBonus = 1 };
            Arm arm05 = new Arm { ArmId = 5, ArmType = "Lagoon", ImageURL = "http://localhost:49263/images/arm_05.png", StatBonus = 1 };
            Arm arm06 = new Arm { ArmId = 6, ArmType = "Demon", ImageURL = "http://localhost:49263/images/arm_06.png", StatBonus = 1 };
            Arm arm07 = new Arm { ArmId = 7, ArmType = "Frank", ImageURL = "http://localhost:49263/images/arm_07.png", StatBonus = 1 };
            Leg leg01 = new Leg { LegId = 1, LegType = "Thin", ImageURL = "http://localhost:49263/images/leg_01.png", StatBonus = 1 };
            Leg leg02 = new Leg { LegId = 2, LegType = "Bones", ImageURL = "http://localhost:49263/images/leg_02.png", StatBonus = 1 };
            Leg leg03 = new Leg { LegId = 3, LegType = "Frank", ImageURL = "http://localhost:49263/images/leg_03.png", StatBonus = 1 };
            Leg leg04 = new Leg { LegId = 4, LegType = "Drumstick", ImageURL = "http://localhost:49263/images/leg_04.png", StatBonus = 1 };
            Leg leg05 = new Leg { LegId = 5, LegType = "Robot", ImageURL = "http://localhost:49263/images/leg_05.png", StatBonus = 1 };
            Leg leg06 = new Leg { LegId = 6, LegType = "Zombie", ImageURL = "http://localhost:49263/images/leg_06.png", StatBonus = 1 };
            Accessory accessory01 = new Accessory { AccessoryId = 1, AccessoryType = "Star", ImageURL = "http://localhost:49263/images/accessory_01.png", StatBonus = 2 };
            Accessory accessory02 = new Accessory { AccessoryId = 2, AccessoryType = "Mustache", ImageURL = "http://localhost:49263/images/accessory_02.png", StatBonus = 2 };
            Accessory accessory03 = new Accessory { AccessoryId = 3, AccessoryType = "Bowler", ImageURL = "http://localhost:49263/images/accessory_03.png", StatBonus = 2 };
            Accessory accessory04 = new Accessory { AccessoryId = 4, AccessoryType = "Teeth", ImageURL = "http://localhost:49263/images/accessory_04.png", StatBonus = 2 };
            Accessory accessory05 = new Accessory { AccessoryId = 5, AccessoryType = "Shades", ImageURL = "http://localhost:49263/images/accessory_05.png", StatBonus = 2 };
            Accessory accessory06 = new Accessory { AccessoryId = 6, AccessoryType = "Glasses", ImageURL = "http://localhost:49263/images/accessory_06.png", StatBonus = 2 };
            Accessory accessory07 = new Accessory { AccessoryId = 7, AccessoryType = "Shades", ImageURL = "http://localhost:49263/images/accessory_07.png", StatBonus = 2 };
            Accessory accessory08 = new Accessory { AccessoryId = 8, AccessoryType = "Earring", ImageURL = "http://localhost:49263/images/accessory_08.png", StatBonus = 2 };
            Accessory accessory09 = new Accessory { AccessoryId = 9, AccessoryType = "Eye", ImageURL = "http://localhost:49263/images/accessory_09.png", StatBonus = 2 };
                
            context.BodyType.AddOrUpdate(
                body01, body02, body03, body04, body05);
            context.Heads.AddOrUpdate(
                head01, head02, head03, head04, head05, head06, head07, head08, head09, head10, head11, head12);
            context.Arms.AddOrUpdate(
                arm01, arm02, arm03, arm04, arm05, arm06, arm07);
            context.Legs.AddOrUpdate(
                leg01, leg02, leg03, leg04, leg05, leg06);
            context.Accessory.AddOrUpdate(
                accessory01, accessory02, accessory03, accessory05, accessory06, accessory07, accessory08, accessory09);
        }
    }
}
