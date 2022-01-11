using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using BAL;
using BAL.Ado.Net;

namespace CareerPortal.Areas.Recruiter.Controllers
{
    public class AllJobsController : Controller
    {
        JobAllPositions jbPositions;
        CandidateLogics candidateobj;
        UserRegModule RegUser;
        AdoNetFetch AdoNet;

        public AllJobsController()
        {
            jbPositions = new JobAllPositions();
            candidateobj = new CandidateLogics();
            RegUser = new UserRegModule() ;
            AdoNet = new AdoNetFetch();
        }
        // GET: Recruiter/AllJobs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateJobs(int Id = 0)
        {
            BindDropdowns();

            JobPositionViewModels model = new JobPositionViewModels();
            if (Id!=0)
            {
                model = jbPositions.GetPosition(Id);

            }

  


            return View(model);
        }
        [HttpPost]
        public ActionResult CreateJobs(JobPositionViewModels model)
        {

            BindDropdowns();


            if (ModelState.IsValid)
            {
                if (model.JobId!=0)
                {
                    jbPositions.UpdatePosition(model);
                    ModelState.Clear();

                    //return RedirectToAction("Index");

                    return Json(new { RedirectUrl = Url.Action("Index") });
                }
                else
                {
                    jbPositions.AddPositions(model);
                    model = new JobPositionViewModels();

                    return View();
                    //ModelState.Clear();
                }

                

    
            }
            else
            {
                return View(model);

            }

 
        }
        public JsonResult DeleteJob(int JobId)
        {


            try
            {

                jbPositions.DeletePosition(JobId);
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {


                return Json(false, JsonRequestBehavior.AllowGet);

            }




        }
        public JsonResult GetJobsDataTable()
        {

            var GetAllJobs = jbPositions.GetAllPositionsInViewModel();

            if (GetAllJobs.ListAlljobs.Count!=0)
            {

                var DtAlJobs = GetAllJobs.ListAlljobs.Select(m => new
                {
                    JobId = m.JobId,
                    JobTitle = m.JobTitle,
                    JobLocation = m.JobLocation,
                    PostedDate = m.PostedDate.Value.ToString("dd-MMM-yyyy"),
                    NoOfVacancy = m.NoOfVacancy,
                    EmployementType = m.EmployementType,
                    SalaryRange = m.SalaryRange,
                    JobDescription = m.JobDescription,
                    NoOfAppliedCnd = m.CandidateJobApplies.Count()
                }).OrderBy(m=>m.PostedDate);

                var JsonResult = Json(new { data = DtAlJobs }, JsonRequestBehavior.AllowGet);

                JsonResult.MaxJsonLength = int.MaxValue;

                return JsonResult;
            }
            else
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);

            }





        }

        public ActionResult ViewJobCandidates(int JobId = 0)
        {
            var db = new JobPositionViewModels();
            if (JobId !=0)
            {
                  db = jbPositions.GetPosition(JobId);
            }



            return View(db);
        }


        public ActionResult CandidateProfile(int UserId = 0)
        {
            var dbobj = new CandidateViewModel();

            if (UserId != 0)
            {
                dbobj = candidateobj.getCandidate(UserId);


            }
        

            return View(dbobj);
        }

        public ActionResult CandidateList()
        {
           
            
             var   dbobj = candidateobj.GetAllUsers();
       

            return View(dbobj);
        }
        public void BindDropdowns()
        {
            var GenderDropdown = new List<SelectListItem>
            {
               new SelectListItem { Text = "Select ", Value = "Select"},
                new SelectListItem { Text = "Any", Value = "3"},
                new SelectListItem { Text = "Male", Value = "1" },
                new SelectListItem { Text = "Female", Value = "2" }
            };
            ViewBag.GenderDropdown = GenderDropdown;


            var EmploymentTypeDropDown = new List<SelectListItem>
            {
               new SelectListItem { Text = "Select ", Value = "Select"},
                new SelectListItem { Text = "Contractual", Value = "Contractual"},
                new SelectListItem { Text = "Permanant", Value = "Permanant" },
                new SelectListItem { Text = "Daily Wage", Value = "Daily Wage" }
            };
            ViewBag.EmploymentType = EmploymentTypeDropDown;


            var GetAllDivision = new SelectList(AdoNet.GetAllDivision(), "DivisionID", "DivisionName").ToList();
            GetAllDivision.Insert(0, (new SelectListItem { Text = "Select Division", Value = "Select" }));
            ViewBag.DivisionDropDown = GetAllDivision;

            var GetAllCategory = new SelectList(AdoNet.GetAllCatgory(), "CategoryId", "CategoryDesc").ToList();
            GetAllCategory.Insert(0, (new SelectListItem { Text = "Select Category", Value = "Select" }));
            ViewBag.CategoryDropDown = GetAllCategory;


            var GetAllDepartment = new SelectList(AdoNet.GetAllDepartment(), "Department_Id", "Department_Name").ToList();
            GetAllDepartment.Insert(0, (new SelectListItem { Text = "Select Department", Value = "Select" }));
            ViewBag.DepartmentDropDown = GetAllDepartment;

            var GetAllDesgination = new SelectList(AdoNet.GetAllDesignation(), "Designation_Id", "Designation_Name").ToList();
            GetAllDesgination.Insert(0, (new SelectListItem { Text = "Select Designation", Value = "Select" }));
            ViewBag.DesignationDropDown = GetAllDesgination;


      




        }

    }
}