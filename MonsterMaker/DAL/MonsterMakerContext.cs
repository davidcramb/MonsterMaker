using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MonsterMaker.Models;

namespace MonsterMaker
{
    public class MonsterMakerContext : ApplicationDbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Monster> Monsters { get; set; }
        public virtual DbSet<Body> BodyType { get; set; }
        public virtual DbSet<Arm> Arms { get; set; }
        public virtual DbSet<Leg> Legs { get; set; }
        public virtual DbSet<Head> Heads { get; set; }
        public virtual DbSet<Accessory> Accessory { get; set; }
        public virtual DbSet<BattleLog> Battles { get; set; }


    }
}