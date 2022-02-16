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
        HRPanelDB HRPanelDB;
        IntEvQuestions dbIntEvQuestions;
        IntEvQuestionsMapping DbIntEvQuestionsMaping;
        DecisionList decisionList;
        CndEvaluationMaster dbcndEvaluationMaster;
        CndEvaluationDetail dbcndEvaluationDetail;


        public ShortlistingController()
        {
            Cand_Shortlisting = new Cand_Shortlisting();
            HR_SlotsTimings = new HR_SlotsTimings();
            jobApplied = new JobApplied();
            HRPanelDB = new HRPanelDB();

            dbIntEvQuestions = new IntEvQuestions();
            DbIntEvQuestionsMaping = new IntEvQuestionsMapping();
            decisionList = new DecisionList();
            dbcndEvaluationMaster = new CndEvaluationMaster();
            dbcndEvaluationDetail = new CndEvaluationDetail();
        }
        public ActionResult Shortlist_Cand(int JobApplyId, int CandId)
        {
            var GetJobApp = jobApplied.GetJobApplied(JobApplyId, CandId);

            CandShortListViewModel CandShortListViewModel = new CandShortListViewModel(); ;

            CandShortListViewModel.jobApplyViewModels = GetJobApp;
            if (GetJobApp != null)
            {
                var dbshortlist = Cand_Shortlisting.GetById(GetJobApp.CndJobApply.Id);
                CandShortListViewModel.HrShortlisting = dbshortlist;
                if (dbshortlist != null)
                {
                    CandShortListViewModel.IsEmailSend = dbshortlist.IsEmailSend.Value;


                    CandShortListViewModel.IsSendJobForm = dbshortlist.IsSendJobForm.Value;

                }


            }

            var UrlLink = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            UrlLink += "Recruiter/CandidateForm/jobApplicationForm";

            CandShortListViewModel.ShortListEmailBody = SendEmail.CallForInterviewEmailBody(GetJobApp.CndJobApply.User.FullName, "Artistic Milliner 2 Head Office", "", "Korangi Industrial near bilal chorangi", "", UrlLink, CandShortListViewModel.IsSendJobForm);
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

                    return Json(new { status = false, message = "Shortlist but failed to send email error message: " + ex.Message }, JsonRequestBehavior.AllowGet);

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

        public ActionResult InterviewList()
        {
 
            return View();
        }
     
        public void BindDropdowns()
        {

            var getSlots = HR_SlotsTimings.GetList();
            var getSlotstiming = getSlots.Select(m => new { SlotsId = m.Id, SlotsTimings = Convert.ToString(m.StartTime.Value.ToString() + " - " + m.EndTime.Value.ToString()) }).ToList();

            var HRSlotsTimings = new SelectList(getSlotstiming, "SlotsId", "SlotsTimings").ToList();
            HRSlotsTimings.Insert(0, (new SelectListItem { Text = "Select Slots", Value = "0" }));
            ViewBag.TimingsSlotsDropdown = HRSlotsTimings;

            var getPanel = HRPanelDB.GetList();
            var DrpPanel = new SelectList(getPanel, "Id", "PanelName").ToList();
            DrpPanel.Insert(0, (new SelectListItem { Text = "Select Panel", Value = "" }));
            ViewBag.DrpInterviewPanel = DrpPanel;







        }

        public JsonResult GetInterviewListDataTable()
        {

            var GetShortlistEmployees = Cand_Shortlisting.GetList();

            if (GetShortlistEmployees.Count != 0)
            {


                var dtInterview = GetShortlistEmployees.Select(m => new
                {
                    HRShortlistId = m.Id,
                    CandidateName = m.CandidateJobApply.User.FullName,
                    PosTitle = m.CandidateJobApply.AllPosition.JobTitle,
                    InterviewDate = m.InterviewDate.Value.ToString("dd-MMM-yyyy"),
                    InterviewTime = m.TimingSlot.StartTime + " - " + m.TimingSlot.EndTime.Value,
                    InterviewStatus = "Shortlist For Interview"
                }).OrderByDescending(m => m.InterviewDate);

                var JsonResult = Json(new { data = dtInterview }, JsonRequestBehavior.AllowGet);

                JsonResult.MaxJsonLength = int.MaxValue;

                return JsonResult;
            }
            else
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);

            }





        }


        public ActionResult InterviewEvaluationForm(int ShortlistId = 0)
        {
            ViewModels.IntEvaluationViewModel intEvaluationViewModel = new IntEvaluationViewModel();
            var cndShortlist = Cand_Shortlisting.GetByid(ShortlistId);

            intEvaluationViewModel.CandShortListViewModel.HrShortlisting = cndShortlist;
            intEvaluationViewModel.intEvDecisions = decisionList.GetList();
            intEvaluationViewModel.intQuestionMappings = DbIntEvQuestionsMaping.GetList();

            intEvaluationViewModel.CndEvMaster = dbcndEvaluationMaster.GetById(ShortlistId);
            if (intEvaluationViewModel.CndEvMaster!=null)
            {
                intEvaluationViewModel.cndEvDetails = dbcndEvaluationDetail.GetList(intEvaluationViewModel.CndEvMaster.Id);


            }


            return View(intEvaluationViewModel);
        }

        [HttpPost]
        public ActionResult InterviewEvaluationForm(IntEvaluationViewModel intEvaluationViewModel,List<cndEvDetail> cndEvDetails)
        {
            if (ModelState.IsValid)
            {
                if (intEvaluationViewModel.CndEvMaster.Id == 0)
                {
                    intEvaluationViewModel.CndEvMaster.fdGivenBy = GlobalUserInfo.UserId;
                    intEvaluationViewModel.CndEvMaster.ShortListId = intEvaluationViewModel.CandShortListViewModel.HrShortlisting.Id;
                    intEvaluationViewModel.CndEvMaster.creationdate = DateTime.Now;
                    intEvaluationViewModel.CndEvMaster.updatetime = DateTime.Now;



                    dbcndEvaluationMaster.AddData(intEvaluationViewModel.CndEvMaster);

                    foreach (var item in intEvaluationViewModel.cndEvDetails)
                    {
                        item.cndEvMasterId = intEvaluationViewModel.CndEvMaster.Id;

                        item.obtainMarks = DbIntEvQuestionsMaping.GetByid(item.MapId.Value).IntScoreType.TotalMarks;
                        dbcndEvaluationDetail.AddData(item);
                    }

                }
                else
                {
                    intEvaluationViewModel.CndEvMaster.updatetime = DateTime.Now;
                    dbcndEvaluationMaster.UpdateData(intEvaluationViewModel.CndEvMaster);


                    var masterdetail = dbcndEvaluationDetail.GetList(intEvaluationViewModel.CndEvMaster.Id);

                    foreach (var item in masterdetail)
                    {
                        dbcndEvaluationDetail.DeleteById(item.Id);
                    }

                    foreach (var item in intEvaluationViewModel.cndEvDetails)
                    {
                        item.cndEvMasterId = intEvaluationViewModel.CndEvMaster.Id;

                        item.obtainMarks = DbIntEvQuestionsMaping.GetByid(item.MapId.Value).IntScoreType.TotalMarks;
                        dbcndEvaluationDetail.AddData(item);
                    }
                    //foreach (var item in intEvaluationViewModel.cndEvDetails)
                    //{

                    //    item.cndEvMasterId = intEvaluationViewModel.CndEvMaster.Id;
                    //    item.obtainMarks = DbIntEvQuestionsMaping.GetByid(item.MapId.Value).IntScoreType.TotalMarks;
                    //    dbcndEvaluationDetail.AddData(item);
                    //}


                }


                var cndShortlist = Cand_Shortlisting.GetByid(intEvaluationViewModel.CandShortListViewModel.HrShortlisting.Id);

                intEvaluationViewModel.CandShortListViewModel.HrShortlisting = cndShortlist;
                intEvaluationViewModel.intEvDecisions = decisionList.GetList();
                intEvaluationViewModel.intQuestionMappings = DbIntEvQuestionsMaping.GetList();

                intEvaluationViewModel.CndEvMaster = dbcndEvaluationMaster.GetById(intEvaluationViewModel.CandShortListViewModel.HrShortlisting.Id);
                if (intEvaluationViewModel.CndEvMaster != null)
                {
                    intEvaluationViewModel.cndEvDetails = dbcndEvaluationDetail.GetList(intEvaluationViewModel.CndEvMaster.Id);


                }
                //return View(intEvaluationViewModel);
                return PartialView("~/Areas/Recruiter/Views/Shared/_CndEvaluationForm.cshtml", intEvaluationViewModel);

            }
            else
            {
                var cndShortlist = Cand_Shortlisting.GetByid(intEvaluationViewModel.CandShortListViewModel.HrShortlisting.Id);

                intEvaluationViewModel.CandShortListViewModel.HrShortlisting = cndShortlist;
                intEvaluationViewModel.intEvDecisions = decisionList.GetList();
                intEvaluationViewModel.intQuestionMappings = DbIntEvQuestionsMaping.GetList();



                //               return View(intEvaluationViewModel);

                return PartialView("~/Areas/Recruiter/Views/Shared/_CndEvaluationForm.cshtml", intEvaluationViewModel);

            }
        

        
        }
    }
}