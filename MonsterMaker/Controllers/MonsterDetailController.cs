using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MonsterMaker.DAL;
using MonsterMaker.Models;
using System.Web.Http.Results;

namespace MonsterMaker.Controllers
{
    public class MonsterDetailController : ApiController
    {
        // GET: api/Create
        MonsterRepository Repo = new MonsterRepository();
        //public IEnumerable<string> GetAll()
        //{
                
        //}
        [Route("Create/api/MonsterDetail/body/{id}")]
        public Body GetBody(int id)
        {
            return Repo.GetBody(id);
        }
        [Route("Create/api/MonsterDetail/head/{id}")]
        public Head GetHead(int id)
        {
            return Repo.GetHead(id);
        }
        [Route("Create/api/MonsterDetail/arm/{id}")]
        public Arm GetArm(int id)
        {
            return Repo.GetArms(id);
        }
        [Route("Create/api/MonsterDetail/leg/{id}")]
        public Leg GetLeg(int id)
        {
            return Repo.GetLegs(id);
        }
        [Route("Create/api/MonsterDetail/accessory/{id}")]
        public Accessory GetAccessory(int id)
        {
            return Repo.GetAccessory(id);
        }

        // GET: api/Create/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Create
        [HttpPost]
        public void Create([FromBody]Monster monsterParts)
        {
            try
            {
                // TODO: Add insert logic here
                Monster newMonster = new Models.Monster
                {
                    BodyId = monsterParts.BodyId,
                    BodyType = monsterParts.BodyType,
                    HeadId = monsterParts.HeadId,
                    HeadType = monsterParts.HeadType,
                    ArmId = monsterParts.ArmId,
                    ArmType = monsterParts.ArmType,
                    LegId = monsterParts.LegId,
                    LegType = monsterParts.LegType,
                    AccessoryId = monsterParts.AccessoryId,
                    AccessoryType = monsterParts.AccessoryType,
                    monsterJSONData = monsterParts.monsterJSONData
                };
            }
            catch
            {
            }
        }
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Create/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Create/5
        public void Delete(int id)
        {
        }
    }
}
