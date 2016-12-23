using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonsterMaker.DAL;
using MonsterMaker.Models;



namespace MonsterMaker.ViewModel
{
    public class CreateMonsterViewModel
    {
        public virtual List<Body> Body { get; set; }
        public virtual List<Head> Head { get; set; }
        public virtual List<Arm> Arm { get; set; }
        public virtual List<Leg> Leg { get; set; }
        public virtual List<Accessory> Accessory { get; set; }

    }
}