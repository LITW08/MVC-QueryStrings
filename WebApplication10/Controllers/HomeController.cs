﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormDemo()
        {
            return View();
        }

        public ActionResult FormSubmit(string firstName)
        {
            FormSubmitDemoViewModel vm = new FormSubmitDemoViewModel
            {
                FirstName = firstName
            };
            return View(vm);
        }
    }
    
}