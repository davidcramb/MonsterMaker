using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MonsterMaker.DAL;
using MonsterMaker.Models;
using MonsterMaker.ViewModel;

namespace MonsterMaker.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext {get;set;}
        // GET: Create
        public ActionResult Create()
        {
        
            this.ApplicationDbContext = new ApplicationDbContext();
            if (ModelState.IsValid)
            {
                ViewBag.IsAuthed = true;
            }
            else
            {
                ViewBag.IsAuthed = false;
            }
            MonsterRepository repo = new MonsterRepository();
            string user_name = User.Identity.Name;
            Maker found_maker = repo.GetUser(user_name);
            Maker maker = new Maker();
            var vModel = new CreateMonsterViewModel();
            vModel.Body = repo.GetBody();
            vModel.Head = repo.GetHead();
            vModel.Arm = repo.GetArms();
            vModel.Leg = repo.GetLegs();
            vModel.Accessory = repo.GetAccessory();
            ViewBag.UserId = found_maker.UserId;
            ViewBag.Bodies = vModel.Body;
            ViewBag.Heads = vModel.Head;
            ViewBag.Arms = vModel.Arm;
            ViewBag.Legs = vModel.Leg;
            ViewBag.Accessories = vModel.Accessory;
            return View(vModel);

        }

        // GET: Create/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: Create/Create
 

        // GET: Create/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Create/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Create/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Create/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
