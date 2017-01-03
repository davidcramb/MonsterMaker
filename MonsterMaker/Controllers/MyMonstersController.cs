using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonsterMaker.Models;
using MonsterMaker.DAL;
using Microsoft.AspNet.Identity;

namespace MonsterMaker.Controllers
{
    [Authorize]
    public class MyMonstersController : Controller
    {
        MonsterRepository repo = new MonsterRepository();
        // GET: MyMonsters
        public ActionResult MyMonsters()
        {
            string user_name = User.Identity.Name;
            Maker found_maker = repo.GetUser(user_name);
            ViewBag.userId = found_maker.UserId;
            return View();
        }

        // GET: MyMonsters/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyMonsters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyMonsters/Create
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

        // GET: MyMonsters/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyMonsters/Edit/5
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

        // GET: MyMonsters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyMonsters/Delete/5
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
