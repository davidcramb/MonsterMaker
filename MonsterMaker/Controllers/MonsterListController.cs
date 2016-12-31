using System;
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
        [Route("MyMonsters/api/MonsterList/User/{id}")]
        public List<Monster> Get(int userId)
        {
            return Repo.GetMonstersByUserId(userId);
        }
        [Route("MyMonsters/api/MonsterList/Monster/{id}")]
        public Monster GetMonster(int monsterId)
        {
            return Repo.GetMonsterByMonsterId(monsterId);
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
