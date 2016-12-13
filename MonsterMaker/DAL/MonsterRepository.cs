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


    }
}