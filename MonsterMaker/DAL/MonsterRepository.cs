using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using MonsterMaker.Models;

namespace MonsterMaker.DAL
{
    public class MonsterRepository
    {
        public MonsterMakerContext Context { get; set; }

        public MonsterRepository(MonsterMakerContext _context)
        {
            Context = _context;
        }
        public MonsterRepository()
        {
            Context = new MonsterMakerContext();
        }

        public List<Maker> GetUsers()
        {
            return Context.Makers.ToList();
        }

        public void AddUser(Maker user)
        {
            Context.Makers.Add(user);
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var error = e;
            }
        }

        public Body GetBody(int id)
        {
            Body body = Context.BodyType.FirstOrDefault(b => b.BodyId == id);
            return body;
        }
        public Head GetHead(int id)
        {
            Head head = Context.Heads.FirstOrDefault(h => h.HeadId == id);
            return head;
        }
        public Arm GetArms(int id)
        {
            Arm arm = Context.Arms.FirstOrDefault(a => a.ArmId == id);
            return arm;
        }
        public Leg GetLegs(int id)
        {
            Leg leg = Context.Legs.FirstOrDefault(l => l.LegId == id);
            return leg;
        }
        public Accessory GetAccessory(int id)
        {
            Accessory extra = Context.Accessory.FirstOrDefault(e => e.AccessoryId == id);
            return extra;
        }

        public List<Monster> GetMonsters()
        {
            return Context.Monsters.ToList();
        }

        public void AddNewMonster(Monster monsterToAdd)
        {
            Context.Monsters.Add(monsterToAdd);

            try
            {
                Context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                var error = e;
            }
        }

        //Just in case this is necessary...
        public void AddNewMonster(string name, int userId, int bodyId, int headId, int armsId, int legsId, int accessoryId)
        {
            Body body = Context.BodyType.FirstOrDefault(b => b.BodyId == bodyId);
            Head head = Context.Heads.FirstOrDefault(h => h.HeadId == headId);
            Arm arm = Context.Arms.FirstOrDefault(a => a.ArmId == armsId);
            Leg leg = Context.Legs.FirstOrDefault(l => l.LegId == legsId);
            Accessory accessory = Context.Accessory.FirstOrDefault(e => e.AccessoryId == accessoryId);
            Maker maker = Context.Makers.FirstOrDefault(m => m.UserId == userId);
            Monster newMonster = new Models.Monster { MonsterName = name, UserId = maker, BodyId = body, HeadId = head, ArmId = arm, LegId = leg, AccessoryId = accessory };
            Context.Monsters.Add(newMonster);
            Context.SaveChanges();
        }

        public void DeleteMonster(Monster monsterToRemove)
        {
            Context.Monsters.Remove(monsterToRemove);
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var error = e;
            }
        }

        public List<Body> GetBody()
        {
            return Context.BodyType.ToList();
        }

        public List<Head> GetHead()
        {
            return Context.Heads.ToList();
        }

        public List<Arm> GetArms()
        {
            return Context.Arms.ToList();
        }

        public List<Leg> GetLegs()
        {
            return Context.Legs.ToList();
        }

        public List<Accessory> GetAccessory()
        {
            return Context.Accessory.ToList();
        }
    }
}