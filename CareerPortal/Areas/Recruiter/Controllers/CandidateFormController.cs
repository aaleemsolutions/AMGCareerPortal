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
    [Authorize]
    public class CandidateFormController : Controller
    {

        LanguagesModel langmodel;
        CandidateLogics candidateobj;
        UserRegModule RegUser;
        AdoNetFetch AdoNet;
        GetUserDetails getusrDetail;
        CandidateLangDbSave cndLang;
        Cand_freindWorking cand_FreindWorking;
        PreivousWorkAtAM Cand_AMPreviousWork;
        DependantsTestClass DependantsTestClass;
        MostRecentEmployementClass MostRecentEmployementClass;
        Cand_ProReferenceClass Cand_ProReferenceClass;

        
        public CandidateFormController()
        {
            langmodel = new LanguagesModel();
            candidateobj = new CandidateLogics();
            RegUser = new UserRegModule();
            AdoNet = new AdoNetFetch();
            getusrDetail = new GetUserDetails();
            cndLang = new CandidateLangDbSave();
            cand_FreindWorking = new Cand_freindWorking();
            Cand_AMPreviousWork = new PreivousWorkAtAM();
            DependantsTestClass = new DependantsTestClass();
            MostRecentEmployementClass = new MostRecentEmployementClass();
            Cand_ProReferenceClass = new Cand_ProReferenceClass();
        }
        public ActionResult Index()
        {

            return View();
        }

    
        public ActionResult jobApplicationForm()
        {
            BindDropdowns();
            var JobApplicationmodel = langmodel.Getdata();

            var dbuser = RegUser.getUser(GlobalUserInfo.UserName);

            var CandidateModel = candidateobj.getCandidate(GlobalUserInfo.UserId);

            CandidateModel.EmailVerifyMessage = dbuser.userinfo.IsEmailVerify.Value;

            //test.CandidateViewModel = new CandidateViewModel();
            JobApplicationmodel.CandidateViewModel = CandidateModel;


            JobApplicationmodel.Cand_RelateFreindWorking = cand_FreindWorking.GetList(GlobalUserInfo.UserId);
            JobApplicationmodel.Cand_AMPreviousWork = Cand_AMPreviousWork.GetByid(GlobalUserInfo.UserId);
            JobApplicationmodel.Cand_Dependants = DependantsTestClass.GetList(GlobalUserInfo.UserId);
            JobApplicationmodel.MostRecentEmployment = MostRecentEmployementClass.GetById(GlobalUserInfo.UserId);
           JobApplicationmodel.Cand_ProfessionalReferences = Cand_ProReferenceClass.GetList(GlobalUserInfo.UserId);

            if (JobApplicationmodel.Cand_ProfessionalReferences.Count == 0)
            {
                JobApplicationmodel.Cand_ProfessionalReferences = null;

            }
            if (JobApplicationmodel.Cand_Dependants.Count == 0)
            {
                JobApplicationmodel.Cand_Dependants = null;

            }
           
                    if (JobApplicationmodel.Cand_RelateFreindWorking.Count == 0)
            {
                JobApplicationmodel.Cand_RelateFreindWorking = null;

            }


           
            return View(JobApplicationmodel);
        }

        [HttpPost]
        
        public ActionResult jobApplicationForm(JobApplicationViewModel model,List<RadioButtonAnswer> radiobutton) 
        {
            BindDropdowns();

            var test1            = HttpContext.Request.Form["radiobutton[English0].Answer"];

            var test = langmodel.Getdata();

            var dbuser = RegUser.getUser(GlobalUserInfo.UserName);

            var radio = radiobutton;


            if (model.CandidateViewModel.CandidateInfo.Id==0)
            {
                var candmodel = candidateobj.AddCandidate(model.CandidateViewModel);
                cndLang.DeleteByUserId(GlobalUserInfo.UserId);

                List<CandidateLang> candidateLangs = new List<CandidateLang>();
                candidateLangs = radiobutton.Select(m => new CandidateLang { LangMapId = m.Answer, LangValue = m.name, UserId = GlobalUserInfo.UserId }).ToList();
                cndLang.AddData(candidateLangs);

                //Freinds Relate Working
                cand_FreindWorking.AddListReocord(model.Cand_RelateFreindWorking);

                Cand_AMPreviousWork.AddData(model.Cand_AMPreviousWork);
                DependantsTestClass.AddForeach(model.Cand_Dependants);
                MostRecentEmployementClass.AddDatabool(model.MostRecentEmployment);
                Cand_ProReferenceClass.AddForeach(model.Cand_ProfessionalReferences);

            }
            else
            {


                var candmodel = candidateobj.UpdateCandidate(model.CandidateViewModel);
                cndLang.DeleteByUserId(GlobalUserInfo.UserId);

                if (radiobutton!=null)
                {
                    List<CandidateLang> candidateLangs = new List<CandidateLang>();
                    candidateLangs = radiobutton.Select(m => new CandidateLang { LangMapId = m.Answer, LangValue = m.name, UserId = GlobalUserInfo.UserId }).ToList();
                    cndLang.AddData(candidateLangs);
                }
           

                //Freinds Relate Working
                cand_FreindWorking.AddListReocord(model.Cand_RelateFreindWorking);

                if(model.Cand_AMPreviousWork!=null)
                    Cand_AMPreviousWork.AddData(model.Cand_AMPreviousWork);
                if (model.Cand_Dependants != null)
                    DependantsTestClass.AddForeach(model.Cand_Dependants);
                if (model.MostRecentEmployment != null)
                    MostRecentEmployementClass.AddDatabool(model.MostRecentEmployment);
                if (model.Cand_ProfessionalReferences != null)
                    Cand_ProReferenceClass.AddForeach(model.Cand_ProfessionalReferences);

            }

            var dbobj = candidateobj.getCandidate(GlobalUserInfo.UserId);
            test.CandidateViewModel = dbobj;
            return View(test);
        
        }

        public JsonResult DeleteCand_Dependants(int Dependand_Id)
        {


            try
            {

                DependantsTestClass.DeleteById(Dependand_Id);
                
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {


                return Json(false, JsonRequestBehavior.AllowGet);

            }




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



            var Gender = new List<SelectListItem>
            {
               new SelectListItem { Text = "Select ", Value = "Select"},
                new SelectListItem { Text = "Male", Value = "Male"},
                new SelectListItem { Text = "Female", Value = "Female" },
                new SelectListItem { Text = "Other", Value = "Other" }

            };
            ViewBag.GenderDropDown = Gender;



            var Dependants = new List<SelectListItem>
            {
               new SelectListItem { Text = "Select ", Value = "Select"},
                new SelectListItem { Text = "Parents", Value = "Parents"},
                new SelectListItem { Text = "Spouse", Value = "Spouse" },
                new SelectListItem { Text = "Kids", Value = "Kids" }

            };
            ViewBag.DependantsDropDown = Dependants;


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