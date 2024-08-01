using PreRegistration.Models;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PreRegistration.Controllers
{
    public class AdminController : Controller
    {
        Logger log = new Logger();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}