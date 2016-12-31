using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MonsterMaker.DAL;
using MonsterMaker.Models;
namespace MonsterMaker.Controllers
{
    public class MyMonstersController : ApiController
    {
        MonsterRepository Repo = new MonsterRepository();
        // GET: api/MyMonsters
        public IEnumerable<Monster> Get()
        {
            return Repo.GetMonsters();
        }

        // GET: api/MyMonsters/5
        public string Get(int userId)
        {
            return "value";
        }

        // POST: api/MyMonsters
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MyMonsters/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MyMonsters/5
        public void Delete(int id)
        {
        }
    }
}
