using BAL;
using BAL.Ado.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.CustomModel;
using System.Web.Mvc;

namespace CareerPortal.Areas.Recruiter.Controllers
{
    public class cvBankController : Controller
    {
        JobAllPositions jbPositions;
        CandidateLogics candidateobj;
        UserRegModule RegUser;
        AdoNetFetch AdoNet;

        public cvBankController()
        {
            jbPositions = new JobAllPositions();
            candidateobj = new CandidateLogics();
            RegUser = new UserRegModule();
            AdoNet = new AdoNetFetch();
        }
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult CvDetail( int CvId)
        {
            var GetAllJobs = AdoNet.GetAllCVCandidate(CvId,true,true,true,true);

            CvMain cvMain = GetAllJobs.FirstOrDefault();

            return View(cvMain);
        }

        public JsonResult GetCVCandidate()
        {
            var GetAllJobs = AdoNet.GetAllCVCandidate();
            var JsonResult = Json(new { data = GetAllJobs }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = int.MaxValue;
            return JsonResult;
        }

    }
}