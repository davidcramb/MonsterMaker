using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MonsterMaker.DAL;
using MonsterMaker.Models;
using System.Web.Http.Results;

namespace MonsterMaker.Controllers
{
    public class MonsterListController : ApiController
    {
        MonsterRepository Repo = new MonsterRepository();
        // GET: api/MyMonsters
        [Route("MyMonsters/api/MonsterList/Monsters")]
        public IEnumerable<Monster> Get()
        {
            return Repo.GetMonsters();
        }

        // GET: api/MyMonsters/5
        [Route("MyMonsters/api/MonsterList/user/{id}")]
        public IEnumerable<Monster> GetId(int id)
        {

            return Repo.GetMonstersByUserId(id);
        }
        [Route("MyMonsters/api/MonsterList/monster/{id}")]
        public Monster GetMonster(int id)
        {
            return Repo.GetMonsterByMonsterId(id);
        }

        // PUT: api/MyMonsters/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MyMonsters/5
        public void Delete(int monsterId)
        {
            Repo.DeleteMonsterByMonsterId(monsterId);
        }
    }
}
