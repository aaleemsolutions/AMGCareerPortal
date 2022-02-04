using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using BAL;
using BAL.DbSaveClass;
using DAL;
using BAL.Utilities;

namespace CareerPortal.Areas.Recruiter.Controllers
{
    [Authorize]
    public class ShortlistingController : Controller
    {
        Cand_Shortlisting Cand_Shortlisting;
        HR_SlotsTimings HR_SlotsTimings;
        JobApplied jobApplied;


        public ShortlistingController()
        {
            Cand_Shortlisting = new Cand_Shortlisting();
            HR_SlotsTimings = new HR_SlotsTimings();
            jobApplied = new JobApplied();
           


        }
        public ActionResult Shortlist_Cand(int JobApplyId,int CandId)
        
        {
            var GetJobApp = jobApplied.GetJobApplied(JobApplyId,CandId);

            CandShortListViewModel CandShortListViewModel   = new CandShortListViewModel(); ;

            CandShortListViewModel.jobApplyViewModels = GetJobApp;
            if (GetJobApp!=null)
            {
                var dbshortlist = Cand_Shortlisting.GetById(GetJobApp.CndJobApply.Id);
                CandShortListViewModel.HrShortlisting = dbshortlist;
                if (dbshortlist!=null)
                {
                    CandShortListViewModel.IsEmailSend = dbshortlist.IsEmailSend.Value;


                    CandShortListViewModel.IsSendJobForm = dbshortlist.IsSendJobForm.Value;

                }


            }

            var UrlLink = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            UrlLink += "Recruiter/CandidateForm/jobApplicationForm";

            CandShortListViewModel.ShortListEmailBody = SendEmail.CallForInterviewEmailBody(GetJobApp.CndJobApply.User.FullName, "Artistic Milliner 2 Head Office","","Korangi Industrial near bilal chorangi","", UrlLink, CandShortListViewModel.IsSendJobForm);
            BindDropdowns();

            


            return PartialView("~/Areas/Recruiter/Views/Shared/_ShortlistCandidate.cshtml", CandShortListViewModel);

         
        }

        [HttpPost]
        public ActionResult Shortlist_Cand(CandShortListViewModel model)

        {
            try
            {
                var shortlistModel = new HrShortlisting();

                shortlistModel = model.HrShortlisting;
                shortlistModel.JobId = model.jobApplyViewModels.CndJobApply.JobId;
                shortlistModel.CandApplyId = model.jobApplyViewModels.CndJobApply.Id;
                shortlistModel.IsEmailSend = model.IsEmailSend;
                shortlistModel.IsSendJobForm = model.IsSendJobForm;
                shortlistModel.CreatedBy = GlobalUserInfo.UserId;


                Cand_Shortlisting.AddData(shortlistModel);
                var UrlLink = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                UrlLink += "Recruiter/CandidateForm/jobApplicationForm";
                var emailbody = SendEmail.CallForInterviewEmailBody(model.jobApplyViewModels.CndJobApply.User.FullName, "Artistic Milliner 2 Head Office", "", "Korangi Industrial near bilal chorangi", "", UrlLink, shortlistModel.IsSendJobForm.Value); 

                try
                {
                    SendEmail.Email(emailbody, "Interview Call", model.jobApplyViewModels.CndJobApply.User.UserEmail);
                }
                catch (Exception ex)
                {

                    return Json(new { status = false, message = "Shortlist but failed to send email error message: " + ex.Message}, JsonRequestBehavior.AllowGet);
 
                }
                

                //var GetJobApp = jobApplied.GetJobApplied(JobApplyId, CandId);

                //CandShortListViewModel CandShortListViewModel = new CandShortListViewModel(); ;

                //CandShortListViewModel.jobApplyViewModels = GetJobApp;

                //BindDropdowns();





                return Json(new { status = true, message = "" }, JsonRequestBehavior.AllowGet);




            }
            catch (Exception ex)
            {
                


                return Json(new { status = false, message = ex.Message }, JsonRequestBehavior.AllowGet);



            }


        }


        public void BindDropdowns()
        {

            var getSlots = HR_SlotsTimings.GetList();
            //var getSlotstiming = test.Select(m=>new { SlotsId = m.Id,SlotsTimings = m.StartTime.Value.ToString("HH:mm") + " - " + m.EndTime.Value.ToString("HH:mm") }).ToList();
            var getSlotstiming = getSlots.Select(m => new { SlotsId = m.Id, SlotsTimings = Convert.ToString(m.StartTime.Value.ToString() + " - " + m.EndTime.Value.ToString() ) }).ToList();

            var HRSlotsTimings = new SelectList(getSlotstiming, "SlotsId", "SlotsTimings").ToList();
            HRSlotsTimings.Insert(0, (new SelectListItem { Text = "Select Slots", Value = "0" }));
            ViewBag.TimingsSlotsDropdown = HRSlotsTimings;
            //ViewBag.DegreeDropDown = getusrDetail.GetAllDegrees().ToList();
            
            //var GetAllDegrees = new SelectList(getusrDetail.GetAllDegrees().ToList(), "Qualification_ID", "Qualification_Name").ToList();
            //GetAllDegrees.Insert(0, (new SelectListItem { Text = "Select Degree", Value = "0" }));
            //ViewBag.DegreeDropDown = GetAllDegrees;
            ////ViewBag.DegreeDropDown = getusrDetail.GetAllDegrees().ToList();

            //List<SelectListItem> MonthNameDropDown = VariableCasting.GetMonthsName.ToList();
            //MonthNameDropDown.Insert(0, (new SelectListItem { Text = "Select Month", Value = "0" }));
            //ViewBag.MonthNameDropdown = MonthNameDropDown.ToList();

            //List<SelectListItem> YearDropdown = new SelectList(Enumerable.Range(1960, (DateTime.Now.Year - 1960) + 1)).ToList();
            //YearDropdown = YearDropdown.Select(m => new SelectListItem { Text = m.Text, Value = m.Text }).ToList();
            //YearDropdown.Insert(0, (new SelectListItem { Text = "Select Year", Value = "0" }));
            //ViewBag.YearDropdown = YearDropdown.ToList().OrderByDescending(m => m.Text);

            //ViewBag.GradeTypes = VariableCasting.GradeTypes().ToList();

            //var MartialStatus = new List<SelectListItem>
            //{
            //   new SelectListItem { Text = "Select ", Value = "Select"},
            //    new SelectListItem { Text = "Single", Value = "Single"},
            //    new SelectListItem { Text = "Married", Value = "1" }

            //};
            //ViewBag.MartialStatusDropDown = MartialStatus;



            //var Gender = new List<SelectListItem>
            //{
            //   new SelectListItem { Text = "Select ", Value = "Select"},
            //    new SelectListItem { Text = "Male", Value = "Male"},
            //    new SelectListItem { Text = "Female", Value = "Female" },
            //    new SelectListItem { Text = "Other", Value = "Other" }

            //};
            //ViewBag.GenderDropDown = Gender;



            //var Dependants = new List<SelectListItem>
            //{
            //   new SelectListItem { Text = "Select ", Value = "Select"},
            //    new SelectListItem { Text = "Parents", Value = "Parents"},
            //    new SelectListItem { Text = "Spouse", Value = "Spouse" },
            //    new SelectListItem { Text = "Kids", Value = "Kids" }

            //};
            //ViewBag.DependantsDropDown = Dependants;

 


        }




    }
}