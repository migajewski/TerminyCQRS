﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Test;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}