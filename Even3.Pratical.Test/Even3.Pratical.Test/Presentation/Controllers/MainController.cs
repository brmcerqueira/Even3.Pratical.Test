﻿using System.Web.Mvc;

namespace Even3.Pratical.Test.Presentation.Controllers
{
    public class MainController : Controller
    {
        public ViewResult Index(string key)
        {
            ViewBag.Registration = key;
            return View();
        }
    }
}
