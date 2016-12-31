using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterMaker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Create a new Monster";

            return RedirectToAction("Create");
        }

        public ActionResult My_Monsters()
        {
            ViewBag.Message = "All my little monsters";
            return RedirectToAction("MyMonsters");
            }
    }
}