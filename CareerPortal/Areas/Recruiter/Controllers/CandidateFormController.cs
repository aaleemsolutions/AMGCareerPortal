using BAL;
using BAL.Ado.Net;
using BAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using BAL.DbSaveClass;
using DAL;

namespace CareerPortal.Areas.Recruiter.Controllers
{
    public class CandidateFormController : Controller
    {

        LanguagesModel langmodel;
        CandidateLogics candidateobj;
        UserRegModule RegUser;
        AdoNetFetch AdoNet;
        GetUserDetails getusrDetail;

        CandidateLangDbSave cndLang;

        public CandidateFormController()
        {
            langmodel = new LanguagesModel();
            candidateobj = new CandidateLogics();
            RegUser = new UserRegModule();
            AdoNet = new AdoNetFetch();
            getusrDetail = new GetUserDetails();
            cndLang = new CandidateLangDbSave();
        }
        public ActionResult Index()
        {
            return View();
        }

    
        public ActionResult jobApplicationForm()
        {
            BindDropdowns();
            var test = langmodel.Getdata();

            var dbuser = RegUser.getUser(GlobalUserInfo.UserName);

            var dbobj = candidateobj.getCandidate(GlobalUserInfo.UserId);

            dbobj.EmailVerifyMessage = dbuser.userinfo.IsEmailVerify.Value;

            //test.CandidateViewModel = new CandidateViewModel();
            test.CandidateViewModel = dbobj;







            return View(test);
        }

        [HttpPost]
        
        public ActionResult jobApplicationForm(JobApplicationViewModel model,List<RadioButtonAnswer> radiobutton) 
        
        {
            BindDropdowns();

            var test1 = HttpContext.Request.Form["radiobutton[English0].Answer"];

            var test = langmodel.Getdata();

            var dbuser = RegUser.getUser(GlobalUserInfo.UserName);

            var radio = radiobutton;


            if (model.CandidateViewModel.CandidateId==0)
            {
                var candmodel = candidateobj.AddCandidate(model.CandidateViewModel);
                List<CandidateLang> candidateLangs = new List<CandidateLang>();
                candidateLangs = radiobutton.Select(m => new CandidateLang { LangMapId = m.Answer, UserId = GlobalUserInfo.UserId }).ToList();
                cndLang.AddData(candidateLangs);

            }
            else
            {

                cndLang.DeleteByUserId(GlobalUserInfo.UserId);

                List<CandidateLang> candidateLangs = new List<CandidateLang>();
                candidateLangs = radiobutton.Select(m => new CandidateLang { LangMapId = m.Answer, UserId = GlobalUserInfo.UserId }).ToList();
                cndLang.AddData(candidateLangs);


                //var candmodel = candidateobj.UpdateCandidate(model.CandidateViewModel);
            }
         

            return View(test);
        
        }

        public void BindDropdowns()
        {

            var GetAllDegrees = new SelectList(getusrDetail.GetAllDegrees().ToList(), "Qualification_ID", "Qualification_Name").ToList();
            GetAllDegrees.Insert(0, (new SelectListItem { Text = "Select Degree", Value = "0" }));
            ViewBag.DegreeDropDown = GetAllDegrees;
            //ViewBag.DegreeDropDown = getusrDetail.GetAllDegrees().ToList();

            List<SelectListItem> MonthNameDropDown = VariableCasting.GetMonthsName.ToList();
            MonthNameDropDown.Insert(0, (new SelectListItem { Text = "Select Month", Value = "0" }));
            ViewBag.MonthNameDropdown = MonthNameDropDown.ToList();

            List<SelectListItem> YearDropdown = new SelectList(Enumerable.Range(1960, (DateTime.Now.Year - 1960) + 1)).ToList();
            YearDropdown = YearDropdown.Select(m => new SelectListItem { Text = m.Text, Value = m.Text }).ToList();
            YearDropdown.Insert(0, (new SelectListItem { Text = "Select Year", Value = "0" }));
            ViewBag.YearDropdown = YearDropdown.ToList().OrderByDescending(m => m.Text);

            ViewBag.GradeTypes = VariableCasting.GradeTypes().ToList();

            var MartialStatus = new List<SelectListItem>
            {
               new SelectListItem { Text = "Select ", Value = "Select"},
                new SelectListItem { Text = "Single", Value = "Single"},
                new SelectListItem { Text = "Married", Value = "1" }
                
            };
            ViewBag.MartialStatusDropDown = MartialStatus;


            //var EmploymentTypeDropDown = new List<SelectListItem>
            //{
            //   new SelectListItem { Text = "Select ", Value = "Select"},
            //    new SelectListItem { Text = "Contractual", Value = "Contractual"},
            //    new SelectListItem { Text = "Permanant", Value = "Permanant" },
            //    new SelectListItem { Text = "Daily Wage", Value = "Daily Wage" }
            //};
            //ViewBag.EmploymentType = EmploymentTypeDropDown;


            //var GetAllDivision = new SelectList(AdoNet.GetAllDivision(), "DivisionID", "DivisionName").ToList();
            //GetAllDivision.Insert(0, (new SelectListItem { Text = "Select Division", Value = "Select" }));
            //ViewBag.DivisionDropDown = GetAllDivision;
 


        }


    }
}