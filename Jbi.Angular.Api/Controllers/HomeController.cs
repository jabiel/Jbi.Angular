﻿using Jbi.Angular.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jbi.Angular.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult InitDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<AuthContext>());
            ViewBag.Title = "Database init";

            return View("Index");
        }
    }
}
