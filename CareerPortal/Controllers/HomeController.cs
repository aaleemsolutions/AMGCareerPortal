using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerPortal.Controllers
{
    public class HomeController : Controller
    {
        JobAllPositions JobPos;
        public HomeController()
        {
            JobPos = new JobAllPositions();
        }

        public ActionResult Index()
         {

            var db = JobPos.GetAllPositionsInViewModel();

            return View(db);
        }

        public ActionResult JobList()
        {
            var db = JobPos.GetAllPositionsInViewModel();

            return View(db);
        }

     
    }
}