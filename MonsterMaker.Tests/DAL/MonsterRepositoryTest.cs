using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterMaker.DAL;
using Moq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MonsterMaker.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonsterMaker.Tests.DAL
{
    [TestClass]
    public class MonsterRepositoryTest
    {
        private Mock<MonsterMakerContext> mock_context { get; set; }
        private Mock<DbSet<Maker>> mock_users { get; set; }
        private Mock<DbSet<Monster>> mock_monsters { get; set; }
        private List<Maker> makers { get; set; }
        private List<Monster> monsters { get; set; }

        private MonsterRepository repo { get; set; }
        private Maker Bob { get; set; }
        private Maker Joe { get; set; }
        private Monster BobsMonster { get; set; }
        private Monster JoesMonster { get; set; }
        
        private Body body01 {get;set;}
        private Head head01 { get; set; }
        private Arm arm01 { get; set; }
        private Leg leg01 { get; set; }
        private Accessory accessory01 { get; set; }
        
        public void ConnectToDataStore()
        {
            var query_users = makers.AsQueryable();
            var query_monsters = monsters.AsQueryable();
            mock_users.As<IQueryable<Maker>>().Setup(user => user.Provider).Returns(query_users.Provider);
            mock_users.As<IQueryable<Maker>>().Setup(user => user.Expression).Returns(query_users.Expression);
            mock_users.As<IQueryable<Maker>>().Setup(user => user.ElementType).Returns(query_users.ElementType);
            mock_users.As<IQueryable<Maker>>().Setup(user => user.GetEnumerator()).Returns(() => query_users.GetEnumerator());
            mock_context.Setup(m => m.Makers).Returns(mock_users.Object);
            mock_users.Setup(u => u.Add(It.IsAny<Maker>())).Callback((Maker u) => makers.Add(u));


            mock_monsters.As<IQueryable<Monster>>().Setup(monster => monster.Provider).Returns(query_monsters.Provider);
            mock_monsters.As<IQueryable<Monster>>().Setup(monster => monster.Expression).Returns(query_monsters.Expression);
            mock_monsters.As<IQueryable<Monster>>().Setup(monster => monster.ElementType).Returns(query_monsters.ElementType);
            mock_monsters.As<IQueryable<Monster>>().Setup(monster => monster.GetEnumerator()).Returns(() => query_monsters.GetEnumerator());
            mock_context.Setup(m => m.Monsters).Returns(mock_monsters.Object);
            mock_monsters.Setup(m => m.Add(It.IsAny<Monster>())).Callback((Monster m) => monsters.Add(m));
            mock_monsters.Setup(m => m.Remove(It.IsAny<Monster>())).Callback((Monster m) => monsters.Remove(m));


        }
        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<MonsterMakerContext>();
            mock_users = new Mock<DbSet<Maker>>();
            mock_monsters = new Mock<DbSet<Monster>>();

            repo = new MonsterRepository(mock_context.Object);
            makers = new List<Maker>();
            monsters = new List<Monster>();
            body01 = new Body { BodyId = 1, BodyType = "Tall", ImageURL = "http://localhost:49263/images/body01.png", StatBonus = 1 };
            head01 = new Head { HeadId = 1, HeadType = "Circle", ImageURL = "http://localhost:49263/images/head01.png", StatBonus = 1 };
            arm01 = new Arm { ArmId = 1, ArmType = "Rectangle", ImageURL = "http://localhost:49263/images/arm01.png", StatBonus = 1 };
            leg01 = new Leg { LegId = 1, LegType = "Thin", ImageURL = "http://localhost:49263/images/leg01.png", StatBonus = 1 };
            accessory01 = new Accessory { AccessoryId = 1, AccessoryType = "Star", ImageURL = "http://localhost:49263/images/accessory01.png", StatBonus = 2 };

            Bob = new Maker { UserId = 1, UserName = "Bob" };
            Joe = new Maker { UserId = 1, UserName = "Joe" };

            BobsMonster = new Monster { MonsterId = 1, MonsterName = "Lunatic", UserId = Bob };
            JoesMonster = new Monster { MonsterId = 1, MonsterName = "Fringe", UserId = Bob };
            makers.Add(Bob); makers.Add(Joe);
            monsters.Add(BobsMonster); monsters.Add(JoesMonster);
            ConnectToDataStore();
        }

        [TestMethod]
        public void EnsureRepoExists()
        {
            MonsterRepository repo = new MonsterRepository();
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void EnsureCanGetUser()
        {
            var users = repo.GetUsers();
            int actual_count = repo.GetUsers().Count();
            int expected_count = 2;
            Assert.IsInstanceOfType(users, typeof(List<Maker>));
            Assert.AreEqual(expected_count, actual_count);
        }
        [TestMethod]
        public void EnsureCanAddUsers()
        {
            Maker Cecil = new Maker { UserId = 3, UserName = "Cecil" };
            repo.AddUser(Cecil);
            Assert.IsTrue(repo.GetUsers().Count() == 3);

        }
        [TestMethod]
        public void EnsureCannotAddUserWithSameUserName()
        {
            Maker FalseBob = new Maker { UserId = 3, UserName = "Bob" };
            int expected_count = 2;
            int actual_count = repo.GetUsers().Count();
        }
        [TestMethod]
        public void EnsureCanGetMonsters()
        {
            int expected_count = 2;
            int actual_count = repo.GetMonsters().Count();
            Assert.AreEqual(expected_count, actual_count);
        }
        [TestMethod]
        public void EnsureCanAddNewMonster()
        {
            Assert.IsTrue(repo.GetMonsters().Count() == 2);
            Monster Mash = new Monster { MonsterId = 3, MonsterName = "Mash", UserId = Bob};
            repo.AddNewMonster(Mash);
            int expected_count = 3;
            int actual_count = repo.GetMonsters().Count();
            Assert.AreEqual(expected_count, actual_count);
        }
        [TestMethod]
        public void EnsureCanDeleteMonster()
        {
            Assert.IsTrue(repo.GetMonsters().Count() == 2);
            repo.DeleteMonster(BobsMonster);
            int expected_count = 1;
            int actual_count = repo.GetMonsters().Count();
            Assert.AreEqual(expected_count, actual_count);
        }
        //[TestMethod]
        //public void EnsureCanAddNewMonsterWithPartIDs()
        //{
        //    Assert.IsTrue(repo.GetMonsters().Count() == 2);
        //    repo.AddNewMonster("Zoltan", 1, 1, 1, 1, 1, 1);
        //    int expected_count = 3;
        //    int actual_count = repo.GetMonsters().Count();
        //    Assert.AreEqual(expected_count, actual_count);
        //}
        [TestMethod]
        public void EnsureCanGetPartsForMonster()
        {
            Assert.IsTrue(repo.GetBody().Count() == 1);
            Assert.IsTrue(repo.GetHead().Count() == 1);
            Assert.IsTrue(repo.GetArms().Count() == 1);
            Assert.IsTrue(repo.GetLegs().Count() == 1);
            Assert.IsTrue(repo.GetAccessory().Count() == 1);
        }
    }
}
