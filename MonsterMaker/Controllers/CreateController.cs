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
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult Create()
        {
            MonsterRepository repo = new MonsterRepository();
            var vModel = new CreateMonsterViewModel();
            vModel.Body = repo.GetBody();
            vModel.Head = repo.GetHead();
            vModel.Arm = repo.GetArms();
            vModel.Leg = repo.GetLegs();
            vModel.Accessory = repo.GetAccessory();
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
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
