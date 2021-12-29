using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerPortal.Areas.CandidatePortal.Controllers
{
    public class CandidatejobController : Controller
    {
        // GET: CandidatePortal/Candidatejob
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JObDetailPartial(int JobId)
        {

            return PartialView("~/Areas/CandidatePortal/Views/Shared/_JobDetailPartial.cshtml");
        }
    }
}