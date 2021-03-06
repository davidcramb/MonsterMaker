﻿    using System;
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
    public class BattleController : Controller
    {
        MonsterRepository repo = new MonsterRepository();

        // GET: Battle
        public ActionResult BattleScreen()
        {
            string user_name = User.Identity.Name;
            Maker found_maker = repo.GetUser(user_name);
            ViewBag.userId = found_maker.UserId;
            return View();
        }

        // GET: Battle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Battle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Battle/Create
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

        // GET: Battle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Battle/Edit/5
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

        // GET: Battle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Battle/Delete/5
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
