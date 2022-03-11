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
using BAL.Ado.Net;
using System.Globalization;
using System.Data.Entity;
using System.Collections;

namespace CareerPortal.Areas.Recruiter.Controllers
{
    [Authorize]
    public class ShortlistingController : Controller
    {
        Cand_Shortlisting Cand_Shortlisting;
        Cand_ShortlistingDetail Cand_ShortlistingDetail;
        HR_SlotsTimings HR_SlotsTimings;
        JobApplied jobApplied;
        HRPanelDB HRPanelDB;
        IntEvQuestions dbIntEvQuestions;
        IntEvQuestionsMapping DbIntEvQuestionsMaping;
        DecisionList decisionList;
        CndEvaluationMaster dbcndEvaluationMaster;
        CndEvaluationDetail dbcndEvaluationDetail;
        UserRegModule dbUserInfo;
        AdoNetFetch AdoNet;
        AdoNetFetch AdoNetDenim;
        JobAllPositions jobAllPositions;
        CandidateLogics DbCandidates;

        CandidateFormController CandidateFormController;


        BAL.EmployeeHiringClass.EmployeeHiringDbClass DbEmployeeHiring;

        public ShortlistingController()
        {
            Cand_Shortlisting = new Cand_Shortlisting();
            Cand_ShortlistingDetail = new Cand_ShortlistingDetail();
            HR_SlotsTimings = new HR_SlotsTimings();
            jobApplied = new JobApplied();
            HRPanelDB = new HRPanelDB();

            dbIntEvQuestions = new IntEvQuestions();
            DbIntEvQuestionsMaping = new IntEvQuestionsMapping();
            decisionList = new DecisionList();
            dbcndEvaluationMaster = new CndEvaluationMaster();
            dbcndEvaluationDetail = new CndEvaluationDetail();
            AdoNet = new AdoNetFetch(CareerGlobalFields.GetConnectionString());
            AdoNetDenim = new AdoNetFetch(CareerGlobalFields.GetConnectionString(false));
            jobAllPositions = new JobAllPositions();


            dbUserInfo = new UserRegModule();
            DbCandidates = new CandidateLogics();
            DbEmployeeHiring = new BAL.EmployeeHiringClass.EmployeeHiringDbClass();

            CandidateFormController = new CandidateFormController();
        }

        public ActionResult LoadShortlistHistory(int ShortListId)
        {
            CandShortListViewModel CandShortListViewModel = new CandShortListViewModel();


            var dbshortlist = Cand_Shortlisting.GetByid(ShortListId);

            CandShortListViewModel.HrShortlisting = dbshortlist;

            return PartialView("~/Areas/Recruiter/Views/Shared/_InterviewHistory.cshtml", CandShortListViewModel);


        }


        public ActionResult Shortlist_Cand(int JobApplyId, int CandId)
        {
            var GetJobApp = jobApplied.GetJobApplied(JobApplyId, CandId);

            CandShortListViewModel CandShortListViewModel = new CandShortListViewModel();

            CandShortListViewModel.jobApplyViewModels = GetJobApp;
            if (GetJobApp != null)
            {
                    var dbshortlist = Cand_Shortlisting.GetById(GetJobApp.CndJobApply.Id);
                    CandShortListViewModel.HrShortlisting = dbshortlist;
                    CandShortListViewModel.HrShortlistingDetail = new HrShortlistingDetail();
                    if (dbshortlist != null)
                    {
                        CandShortListViewModel.HrShortlistingDetail = dbshortlist.HrShortlistingDetails.LastOrDefault();
                }


                if (dbshortlist != null)
                {
                    CandShortListViewModel.IsEmailSend = dbshortlist.HrShortlistingDetails.LastOrDefault().IsEmailSend.Value;


                    CandShortListViewModel.IsSendJobForm = dbshortlist.HrShortlistingDetails.LastOrDefault().IsSendJobForm.Value;

                }


            }

            var UrlLink = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            UrlLink += "Recruiter/CandidateForm/jobApplicationForm";

            CandShortListViewModel.ShortListEmailBody = SendEmail.CallForInterviewEmailBody(GetJobApp.CndJobApply.User.FullName, "Artistic Milliner 2 Head Office", "", "Korangi Industrial near bilal chorangi", GlobalUserInfo.FullName, UrlLink, CandShortListViewModel.IsSendJobForm);
            BindDropdowns(true);




            return PartialView("~/Areas/Recruiter/Views/Shared/_ShortlistCandidate.cshtml", CandShortListViewModel);


        }

        [HttpPost]
        public ActionResult Shortlist_Cand([Bind(Exclude = "HrShortlistingDetail.DecisionId")]  CandShortListViewModel model,string InterviewTiming)
        {
             
            try
            {
                using (var context = new DAL.CareerPortalEntities1())
                {
                    using (DbContextTransaction dbTran = context.Database.BeginTransaction())
                    {
                        try
                        {

                            var shortlistModel = new HrShortlisting();
                            var shortlistingDetail = new HrShortlistingDetail();
                            shortlistingDetail = model.HrShortlistingDetail;
                            shortlistModel = model.HrShortlisting;
                            shortlistModel.IsActive = true;
                            shortlistModel.JobId = model.jobApplyViewModels.CndJobApply.JobId;
                            shortlistModel.CandApplyId = model.jobApplyViewModels.CndJobApply.Id;
                            shortlistingDetail.IsEmailSend = model.IsEmailSend;
                            shortlistingDetail.IsSendJobForm = model.IsSendJobForm;

                            context.HrShortlistings.Add(shortlistModel);
                            context.SaveChanges();
                            if (shortlistModel.Id != 0)
                            {
                                shortlistingDetail.ShortListId = shortlistModel.Id;
                                shortlistingDetail.IsInterviewConfirmed = false;
                                shortlistingDetail.CreatedDate = DateTime.Now;
                                shortlistingDetail.CreatedBy = GlobalUserInfo.UserId;
                                shortlistingDetail.IsActive = true;
                                TimeSpan time = new TimeSpan();

                                time = DateTime.ParseExact(InterviewTiming, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;

                                shortlistingDetail.StartTime = time;
                                shortlistingDetail.DecisionId = 5;

                                //Cand_ShortlistingDetail.AddData(shortlistingDetail);
                                context.HrShortlistingDetails.Add(shortlistingDetail);
                                context.SaveChanges();
                            }
                           
                            dbTran.Commit();

                        }
                        catch (Exception ex)
                        {
                            dbTran.Rollback();
                            throw;
                        }
                    }

                }




                //    var UrlLink = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                var UrlLink = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                UrlLink += "Recruiter/CandidateForm/jobApplicationForm";
                //                var emailbody = SendEmail.CallForInterviewEmailBody(model.jobApplyViewModels.CndJobApply.User.FullName, "Artistic Milliner 2 Head Office", "", "Korangi Industrial near bilal chorangi", "", UrlLink, shortlistingDetail.IsSendJobForm.Value);
                var emailbody = model.ShortListEmailBody;

                try
                {
                    SendEmail.Email(emailbody, "Interview Call", model.jobApplyViewModels.CndJobApply.User.UserEmail);
                }
                catch (Exception ex)
                {

                    return Json(new { status = false, message = "Shortlist but failed to send email error message: " + ex.Message }, JsonRequestBehavior.AllowGet);

                }






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
                    InterviewDate = m.HrShortlistingDetails.LastOrDefault().InterviewDate!=null? m.HrShortlistingDetails.LastOrDefault().InterviewDate.Value.ToString("dd-MMM-yyyy"):"-",
                    InterviewTime = m.HrShortlistingDetails.LastOrDefault().StartTime!=null ? m.HrShortlistingDetails.LastOrDefault().StartTime.Value.ToString(@"hh\:mm"):"-",
                   
                    InterviewStatus = m.EvDecisionId != null ? m.IntEvDecision.DecisionName : "Shortlist For Interview"
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

        public ActionResult InterviewEvaluationList()
        {
            BindDropdowns();




            return View();
        }
        public void BindDropdowns(bool IsshortlistPanel = false)
        {
            if (IsshortlistPanel == true)
            {
                var getSlots = HR_SlotsTimings.GetList();
                var getSlotstiming = getSlots.Select(m => new { SlotsId = m.Id, SlotsTimings = Convert.ToString(m.StartTime.Value.ToString() + " - " + m.EndTime.Value.ToString()) }).ToList();

                var HRSlotsTimings = new SelectList(getSlotstiming, "SlotsId", "SlotsTimings").ToList();
                HRSlotsTimings.Insert(0, (new SelectListItem { Text = "Select Slots", Value = "" }));
                ViewBag.TimingsSlotsDropdown = HRSlotsTimings;

                var getPanel = HRPanelDB.GetList();
                var DrpPanel = new SelectList(getPanel, "Id", "PanelName").ToList();
                DrpPanel.Insert(0, (new SelectListItem { Text = "Select Panel", Value = "" }));
                ViewBag.DrpInterviewPanel = DrpPanel;


            }
            else
            {
                var getSlots = HR_SlotsTimings.GetList();
                var getSlotstiming = getSlots.Select(m => new { SlotsId = m.Id, SlotsTimings = Convert.ToString(m.StartTime.Value.ToString() + " - " + m.EndTime.Value.ToString()) }).ToList();

                var HRSlotsTimings = new SelectList(getSlotstiming, "SlotsId", "SlotsTimings").ToList();
                HRSlotsTimings.Insert(0, (new SelectListItem { Text = "Select Slots", Value = "" }));
                ViewBag.TimingsSlotsDropdown = HRSlotsTimings;

                var getPanel = HRPanelDB.GetList();
                var DrpPanel = new SelectList(getPanel, "Id", "PanelName").ToList();
                DrpPanel.Insert(0, (new SelectListItem { Text = "Select Panel", Value = "" }));
                ViewBag.DrpInterviewPanel = DrpPanel;


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
                GetAllCategory.Insert(0, (new SelectListItem { Text = "Select Category", Value = "-1" }));
                ViewBag.CategoryDropDown = GetAllCategory;


                var GetAllDepartment = new SelectList(AdoNet.GetAllDepartment(), "Department_Id", "Department_Name").ToList();
                GetAllDepartment.Insert(0, (new SelectListItem { Text = "Select Department", Value = "" }));
                ViewBag.DepartmentDropDown = GetAllDepartment;

                var GetAllDesgination = new SelectList(AdoNet.GetAllDesignation(), "Designation_Id", "Designation_Name").ToList();
                GetAllDesgination.Insert(0, (new SelectListItem { Text = "Select Designation", Value = "" }));
                ViewBag.DesignationDropDown = GetAllDesgination;




            }






        }

        public void BindDropdowns(CandShortListViewModel  shortlistmodel,bool IsshortlistPanel = false)
        {
            if (IsshortlistPanel == true)
            {
                var getSlots = HR_SlotsTimings.GetList();
                var getSlotstiming = getSlots.Select(m => new { SlotsId = m.Id, SlotsTimings = Convert.ToString(m.StartTime.Value.ToString() + " - " + m.EndTime.Value.ToString()) }).ToList();

                var HRSlotsTimings = new SelectList(getSlotstiming, "SlotsId", "SlotsTimings").ToList();
                HRSlotsTimings.Insert(0, (new SelectListItem { Text = "Select Slots", Value = "" }));
                ViewBag.TimingsSlotsDropdown = HRSlotsTimings;

                var getPanel = HRPanelDB.GetList();
                var DrpPanel = new SelectList(getPanel, "Id", "PanelName").ToList();
                DrpPanel.Insert(0, (new SelectListItem { Text = "Select Panel", Value = "" }));
                ViewBag.DrpInterviewPanel = DrpPanel;


            }
            else
            {
                var getSlots = HR_SlotsTimings.GetList();
                var getSlotstiming = getSlots.Select(m => new { SlotsId = m.Id, SlotsTimings = Convert.ToString(m.StartTime.Value.ToString() + " - " + m.EndTime.Value.ToString()) }).ToList();

                var HRSlotsTimings = new SelectList(getSlotstiming, "SlotsId", "SlotsTimings").ToList();
                HRSlotsTimings.Insert(0, (new SelectListItem { Text = "Select Slots", Value = "" }));
                ViewBag.TimingsSlotsDropdown = HRSlotsTimings;

                var getPanel = HRPanelDB.GetList();
                var DrpPanel = new SelectList(getPanel, "Id", "PanelName").ToList();
                DrpPanel.Insert(0, (new SelectListItem { Text = "Select Panel", Value = "" }));
                ViewBag.DrpInterviewPanel = DrpPanel;


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


                //var GetAllDivision = new SelectList(AdoNet.GetAllDivision(), "DivisionID", "DivisionName").ToList();
                //GetAllDivision.Insert(0, (new SelectListItem { Text = "Select Division", Value = "Select" }));
                //ViewBag.DivisionDropDown = GetAllDivision;

                //var GetAllCategory = new SelectList(AdoNet.GetAllCatgory(), "CategoryId", "CategoryDesc").ToList();
                //GetAllCategory.Insert(0, (new SelectListItem { Text = "Select Category", Value = "-1" }));
                //ViewBag.CategoryDropDown = GetAllCategory;


                //var GetAllDepartment = new SelectList(AdoNet.GetAllDepartment(), "Department_Id", "Department_Name").ToList();
                //GetAllDepartment.Insert(0, (new SelectListItem { Text = "Select Department", Value = "" }));
                //ViewBag.DepartmentDropDown = GetAllDepartment;

                //var GetAllDesgination = new SelectList(AdoNet.GetAllDesignation(), "Designation_Id", "Designation_Name").ToList();
                //GetAllDesgination.Insert(0, (new SelectListItem { Text = "Select Designation", Value = "" }));
                //ViewBag.DesignationDropDown = GetAllDesgination;

                if (shortlistmodel.HrShortlisting.AllPosition.DivisionName != null)
                {

                    if (!shortlistmodel.HrShortlisting.AllPosition.DivisionName.Contains("Denim") && !shortlistmodel.HrShortlisting.AllPosition.DivisionName.Contains("Spinning"))
                    {
                        var GetAllDivision = new SelectList(AdoNet.GetAllDivision(), "DivisionID", "DivisionName").ToList();
                        GetAllDivision.Insert(0, (new SelectListItem { Text = "Select Division", Value = "" }));
                        ViewBag.DivisionDropDown = GetAllDivision;

                        var GetAllCategory = new SelectList(AdoNet.GetAllCatgory(), "CategoryId", "CategoryDesc").ToList();
                        GetAllCategory.Insert(0, (new SelectListItem { Text = "Select Category", Value = "" }));
                        ViewBag.CategoryDropDown = GetAllCategory;


                        var GetAllDepartment = new SelectList(AdoNet.GetAllDepartment(), "Department_Id", "Department_Name").ToList();
                        GetAllDepartment.Insert(0, (new SelectListItem { Text = "Select Department", Value = "" }));
                        ViewBag.DepartmentDropDown = GetAllDepartment;

                        var GetAllDesgination = new SelectList(AdoNet.GetAllDesignation(), "Designation_Id", "Designation_Name").ToList();
                        GetAllDesgination.Insert(0, (new SelectListItem { Text = "Select Designation", Value = "" }));
                        ViewBag.DesignationDropDown = GetAllDesgination;


                        var GetAllBranches = new SelectList(AdoNet.GetAllbranch(), "BranchID", "BranchName").ToList();
                        GetAllBranches.Insert(0, (new SelectListItem { Text = "Select Branch", Value = "" }));
                        ViewBag.BranchDropdown = GetAllBranches;

                    }
                    else
                    {
                        var GetAllDivision = new SelectList(AdoNet.GetAllDivision(), "DivisionID", "DivisionName").ToList();
                        GetAllDivision.Insert(0, (new SelectListItem { Text = "Select Division", Value = "" }));
                        ViewBag.DivisionDropDown = GetAllDivision;

                        var GetAllCategory = new SelectList(AdoNetDenim.GetAllCatgory(), "CategoryId", "CategoryDesc").ToList();
                        GetAllCategory.Insert(0, (new SelectListItem { Text = "Select Category", Value = "" }));
                        ViewBag.CategoryDropDown = GetAllCategory;


                        var GetAllDepartment = new SelectList(AdoNetDenim.GetAllDepartment(), "Department_Id", "Department_Name").ToList();
                        GetAllDepartment.Insert(0, (new SelectListItem { Text = "Select Department", Value = "" }));
                        ViewBag.DepartmentDropDown = GetAllDepartment;

                        var GetAllDesgination = new SelectList(AdoNetDenim.GetAllDesignation(), "Designation_Id", "Designation_Name").ToList();
                        GetAllDesgination.Insert(0, (new SelectListItem { Text = "Select Designation", Value = "" }));
                        ViewBag.DesignationDropDown = GetAllDesgination;


                        var GetAllBranches = new SelectList(AdoNetDenim.GetAllbranch(), "BranchID", "BranchName").ToList();
                        GetAllBranches.Insert(0, (new SelectListItem { Text = "Select Branch", Value = "" }));
                        ViewBag.BranchDropdown = GetAllBranches;


                    }


                }
                else
                {
                    var GetAllDivision = new SelectList(AdoNet.GetAllDivision(), "DivisionID", "DivisionName").ToList();
                    GetAllDivision.Insert(0, (new SelectListItem { Text = "Select Division", Value = "" }));
                    ViewBag.DivisionDropDown = GetAllDivision;

                    var GetAllCategory = new SelectList(AdoNet.GetAllCatgory(), "CategoryId", "CategoryDesc").ToList();
                    GetAllCategory.Insert(0, (new SelectListItem { Text = "Select Category", Value = "" }));
                    ViewBag.CategoryDropDown = GetAllCategory;


                    var GetAllDepartment = new SelectList(AdoNet.GetAllDepartment(), "Department_Id", "Department_Name").ToList();
                    GetAllDepartment.Insert(0, (new SelectListItem { Text = "Select Department", Value = "" }));
                    ViewBag.DepartmentDropDown = GetAllDepartment;

                    var GetAllDesgination = new SelectList(AdoNet.GetAllDesignation(), "Designation_Id", "Designation_Name").ToList();
                    GetAllDesgination.Insert(0, (new SelectListItem { Text = "Select Designation", Value = "" }));
                    ViewBag.DesignationDropDown = GetAllDesgination;


                    var GetAllBranches = new SelectList(AdoNet.GetAllbranch(), "BranchID", "BranchName").ToList();
                    GetAllBranches.Insert(0, (new SelectListItem { Text = "Select Branch", Value = "" }));
                    ViewBag.BranchDropdown = GetAllBranches;
                }



            }






        }

        public ActionResult InterviewEvaluationForm(int ShortlistId = 0)
        {
          
            ViewModels.IntEvaluationViewModel intEvaluationViewModel = new IntEvaluationViewModel();

            intEvaluationViewModel.CandShortListViewModel = getShortlistCandidate(ShortlistId, intEvaluationViewModel);
          
            intEvaluationViewModel.intEvDecisions = decisionList.GetList();
            
            intEvaluationViewModel.intQuestionMappings = DbIntEvQuestionsMaping.GetList();

            intEvaluationViewModel.CndEvMaster = dbcndEvaluationMaster.GetById(ShortlistId);
           
            if (intEvaluationViewModel.CndEvMaster != null)
            {
                intEvaluationViewModel.cndEvDetails = dbcndEvaluationDetail.GetList(intEvaluationViewModel.CndEvMaster.Id);
            }
            else
            {
                intEvaluationViewModel.CndEvMaster = new cndEvMaster();
            }
           
            intEvaluationViewModel.CndEvMaster.DesignationId = intEvaluationViewModel.CandShortListViewModel.HrShortlisting.AllPosition.DesignationId;
            
            intEvaluationViewModel.CndEvMaster.DepartmentId = intEvaluationViewModel.CandShortListViewModel.HrShortlisting.AllPosition.DepartmentId;

            if (intEvaluationViewModel.CandShortListViewModel.OldShortlistDecisionId != 2)
            {
                intEvaluationViewModel.CandShortListViewModel.HrShortlistingDetail.InterviewDate = null;
                intEvaluationViewModel.CandShortListViewModel.HrShortlistingDetail.PanelId = null;
                intEvaluationViewModel.CandShortListViewModel.HrShortlistingDetail.StartTime = null; 
            }
           
            ViewBag.FeedbackGivenBy = intEvaluationViewModel.CndEvMaster.fdGivenBy != null ? dbUserInfo.getUser(intEvaluationViewModel.CndEvMaster.fdGivenBy.Value).userinfo.FullName : GlobalUserInfo.FullName;

            BindDropdowns(intEvaluationViewModel.CandShortListViewModel);

            return View(intEvaluationViewModel);
        }

        [HttpPost]
        public ActionResult InterviewEvaluationForm([Bind(Exclude = "IntEvaluationViewModel.CandShortListViewModel.HrShortlistingDetail.DecisionId,IntEvaluationViewModel.CandShortListViewModel.HrShortlistingDetail.StartTime")] IntEvaluationViewModel intEvaluationViewModel, List<cndEvDetail> cndEvDetails, [Bind(Exclude = "shortListViewModel.HrShortlistingDetail.StartTime")] ViewModels.CandShortListViewModel shortListViewModel)
        {


            var FormStartTime = Request["HrShortlistingDetail.StartTime"].ToString();
        

            var totalModelError = ViewData.ModelState.Values.Where(v => v.Errors.Count != 0).Count();

            BindDropdowns(intEvaluationViewModel.CandShortListViewModel);

            if (ModelState.IsValid || totalModelError <= 1)
            {
                TimeSpan time = new TimeSpan();

                if (FormStartTime!="")
                {
                    time = DateTime.ParseExact(FormStartTime, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                }

                shortListViewModel.HrShortlistingDetail.StartTime = time;
                
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
                
                    addUpdateShortlistCandidate(shortListViewModel, intEvaluationViewModel);

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

                    addUpdateShortlistCandidate(shortListViewModel, intEvaluationViewModel);

                }
                intEvaluationViewModel.CandShortListViewModel = getShortlistCandidate(intEvaluationViewModel.CndEvMaster.ShortListId.Value, intEvaluationViewModel);
                intEvaluationViewModel.intEvDecisions = decisionList.GetList();
                intEvaluationViewModel.intQuestionMappings = DbIntEvQuestionsMaping.GetList();
                if (intEvaluationViewModel.CndEvMaster != null)
                {
                    intEvaluationViewModel.cndEvDetails = dbcndEvaluationDetail.GetList(intEvaluationViewModel.CndEvMaster.Id);
                }
                intEvaluationViewModel.Status = true;
                intEvaluationViewModel.Message = "Feedback Updated";
                if (intEvaluationViewModel.CndEvMaster.IntEvDecisionId == 1)
                {
                    var JobPosition = jobAllPositions.GetPosition(intEvaluationViewModel.CandShortListViewModel.jobApplyViewModels.CndJobApply.JobId.Value);
                    JobPosition.IsPositionOpen = false;
                    jobAllPositions.UpdatePosition(JobPosition);
                }
                return PartialView("~/Areas/Recruiter/Views/Shared/_CndEvaluationForm.cshtml", intEvaluationViewModel);
            }
            else
            {
                intEvaluationViewModel.CandShortListViewModel = getShortlistCandidate(intEvaluationViewModel.CndEvMaster.ShortListId != null ? intEvaluationViewModel.CndEvMaster.ShortListId.Value : 0, intEvaluationViewModel);
                intEvaluationViewModel.intEvDecisions = decisionList.GetList();
                intEvaluationViewModel.intQuestionMappings = DbIntEvQuestionsMaping.GetList();
                intEvaluationViewModel.Status = false;
                return PartialView("~/Areas/Recruiter/Views/Shared/_CndEvaluationForm.cshtml", intEvaluationViewModel);
            }


         }

        public JsonResult GetInterviewEVDataTable()
        {

            var GetShortlistEmployees = dbcndEvaluationMaster.GetList();

            if (GetShortlistEmployees.Count != 0)
            {
                var dtInterview = GetShortlistEmployees.Select(m => new
                { 
                  EVID = m.Id,
                  ShortListId = m.ShortListId,
                  CandidateName = m.HrShortlisting.CandidateJobApply.User.FullName,
                  PosTitle = m.HrShortlisting.AllPosition.JobTitle,
                  FeedbackGivenBy = dbUserInfo.getUser(m.fdGivenBy.Value).userinfo.FullName,
                  Status = m.IntEvDecision.DecisionName,
                  FeedbackOn = m.creationdate.Value.ToString("dd-MMM-yyyy"),
                  FeedbackUpdatedOn = m.updatetime.Value.ToString("dd-MMM-yyyy"),
                  OverallRating = Math.Round((m.ObtainedMarks.Value * 5) / m.TotalMarks.Value, 0)
                }).OrderByDescending(m => m.FeedbackOn);

                var JsonResult = Json(new { data = dtInterview }, JsonRequestBehavior.AllowGet);

                JsonResult.MaxJsonLength = int.MaxValue;

                return JsonResult;
            }
            else
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);

            }


        }




        public void addUpdateShortlistCandidate(CandShortListViewModel shortListViewModel, IntEvaluationViewModel intEvaluationViewModel = null)
        {
            var cndShortlist = Cand_Shortlisting.GetByid(shortListViewModel.HrShortlisting.Id);
            //var oldShortListDtl = cndShortlist.HrShortlistingDetails.Where(m => m.DecisionId == intEvaluationViewModel.CndEvMaster.IntEvDecisionId.Value).LastOrDefault();
            var oldShortListDtl = cndShortlist.HrShortlistingDetails.Where(m => m.ShortListId == cndShortlist.Id).LastOrDefault();

            var shortlistingDetail = new HrShortlistingDetail();
            shortlistingDetail = shortListViewModel.HrShortlistingDetail;

            shortlistingDetail.IsEmailSend = shortListViewModel.IsEmailSend;
            shortlistingDetail.IsSendJobForm = shortListViewModel.IsSendJobForm;
            shortlistingDetail.StartTime = shortListViewModel.HrShortlistingDetail.StartTime;
            cndShortlist.EvDecisionId = intEvaluationViewModel.CndEvMaster.IntEvDecisionId;
            Cand_Shortlisting.UpdateData(cndShortlist);

            if (cndShortlist.Id != 0)
            {
                shortlistingDetail.ShortListId = cndShortlist.Id;
                shortlistingDetail.DecisionId = cndShortlist.EvDecisionId;

                if (shortlistingDetail.DecisionId != 2 || shortlistingDetail.DecisionId != 5)
                {
                    shortlistingDetail.InterviewDate = null;
                    shortlistingDetail.StartTime= null;
                }


                //if (shortlistingDetail.DecisionId == 2)
                if (2 == 2)
                {
                    //if ((oldShortListDtl != null ? oldShortListDtl.DecisionId : 1) == shortlistingDetail.DecisionId)
                    if ((oldShortListDtl != null ? oldShortListDtl.DecisionId : 0) == shortlistingDetail.DecisionId)
                    {
                        shortlistingDetail.CreatedBy = oldShortListDtl.CreatedBy;
                        shortlistingDetail.CreatedDate = oldShortListDtl.CreatedDate;

                        shortlistingDetail.IsActive = oldShortListDtl.IsActive;
                        shortlistingDetail.Id = oldShortListDtl.Id;
                        Cand_ShortlistingDetail.UpdateData(shortlistingDetail);
                    }
                    else
                    {
                        shortlistingDetail.IsInterviewConfirmed = false;
                        shortlistingDetail.CreatedBy = GlobalUserInfo.UserId;
                        shortlistingDetail.CreatedDate = DateTime.Now;
                        shortlistingDetail.IsActive = true;
                        Cand_ShortlistingDetail.AddData(shortlistingDetail);

                    }
                }

            }


        }



        public CandShortListViewModel getShortlistCandidate(int ShortlistId, ViewModels.IntEvaluationViewModel intEvaluationViewModel)
        {
            ViewModels.CandShortListViewModel candShortListViewModel = new CandShortListViewModel();
            var cndShortlist = Cand_Shortlisting.GetByid(ShortlistId);
            candShortListViewModel.HrShortlisting = cndShortlist;
            candShortListViewModel.jobApplyViewModels = new JobApplyViewModels();

            if (candShortListViewModel.HrShortlisting != null)
            {
                candShortListViewModel.jobApplyViewModels.CndJobApply = candShortListViewModel.HrShortlisting.CandidateJobApply;
                candShortListViewModel.jobApplyViewModels.UserId = candShortListViewModel.HrShortlisting.CandidateJobApply.UserId;
                candShortListViewModel.jobApplyViewModels.User = candShortListViewModel.HrShortlisting.CandidateJobApply.User;
                candShortListViewModel.HrShortlistingDetail = candShortListViewModel.HrShortlisting.HrShortlistingDetails.Where(m => m.DecisionId != null).LastOrDefault();
                if (candShortListViewModel.HrShortlistingDetail != null)
                    candShortListViewModel.OldShortlistDecisionId = candShortListViewModel.HrShortlistingDetail.DecisionId.Value;
            }

            return candShortListViewModel;


        }


        public JsonResult HireEmployeeInHRMS(int EvMasterId = 0, int ShortListId = 0, int UserId = 0, int JobId = 0)
        {

            EmployeeHiringViewModel employeeHiringViewModel = new EmployeeHiringViewModel();
            if (UserId !=0)
            {
                employeeHiringViewModel.UserViewModel = dbUserInfo.getUser(UserId);
                employeeHiringViewModel.CandidateViewModel = DbCandidates.getCandidate(UserId);
                employeeHiringViewModel.CandShortListViewModel.HrShortlisting = Cand_Shortlisting.GetByid(ShortListId);
                employeeHiringViewModel.IntEvaluationViewModel.CndEvMaster = dbcndEvaluationMaster.GetByid(EvMasterId);
                employeeHiringViewModel.JobPositionViewModels = jobAllPositions.GetPosition(employeeHiringViewModel.CandShortListViewModel.HrShortlisting.JobId.Value);
                employeeHiringViewModel.JobPositionViewModels = jobAllPositions.GetPosition(employeeHiringViewModel.CandShortListViewModel.HrShortlisting.JobId.Value);

                employeeHiringViewModel.JobApplicationViewModel = CandidateFormController.GetJobAppViewModels(UserId);

                int NewEmpCode  = SqlEmployeeHiring(employeeHiringViewModel);

                employeeHiringViewModel.IntEvaluationViewModel.CndEvMaster.HiredEmpCode = NewEmpCode.ToString();
                dbcndEvaluationMaster.UpdateData(employeeHiringViewModel.IntEvaluationViewModel.CndEvMaster);

            }


            SenJsonResponse senJsonResponse = new SenJsonResponse();

            senJsonResponse.message = "Saved Successfully";

            senJsonResponse.title = "Saved!";

            return Json(senJsonResponse, JsonRequestBehavior.AllowGet);

        }

        public int SqlEmployeeHiring(EmployeeHiringViewModel employeeHiringViewModel)
        {
            if (employeeHiringViewModel.CandidateViewModel.CandidateInfo==null)
            {
                employeeHiringViewModel.CandidateViewModel.CandidateInfo = new candidate();

            }

            if (employeeHiringViewModel.JobApplicationViewModel.Cand_ProfessionalReferences == null)
            {
                employeeHiringViewModel.JobApplicationViewModel.Cand_ProfessionalReferences = new List<Cand_ProfessionalReferences>();
            }

          
            DAL.CustomModel.EmployeeHiringClass employeeHiringClass = new DAL.CustomModel.EmployeeHiringClass();
            employeeHiringClass.EmployeePic = null;
            employeeHiringClass.EmployeeID = 0;
            employeeHiringClass.TrialID = 0;
            employeeHiringClass.EmployeeCode = null;
            employeeHiringClass.EmployeeName = employeeHiringViewModel.UserViewModel.userinfo.FullName;
            employeeHiringClass.Relation = null;
            employeeHiringClass.FatherName = employeeHiringViewModel.CandidateViewModel.CandidateInfo.FatherName;
            employeeHiringClass.GradeID = employeeHiringViewModel.IntEvaluationViewModel.CndEvMaster.GradeId;
            employeeHiringClass.Designation_ID = employeeHiringViewModel.JobPositionViewModels.DesignationId.Value;
            employeeHiringClass.Department_ID = employeeHiringViewModel.JobPositionViewModels.DepartmentId.Value;
            employeeHiringClass.SectionID = 0;
            employeeHiringClass.SubSectionID = 0;
            employeeHiringClass.UnitID = 0;
            employeeHiringClass.PersonalEmail = employeeHiringViewModel.UserViewModel.userinfo.UserEmail;
            employeeHiringClass.ICENumber = null;
            employeeHiringClass.LanguageID = 1;
            employeeHiringClass.OfficialMobile = employeeHiringViewModel.CandidateViewModel.CandidateInfo.ContactNoOffice;
            employeeHiringClass.WhatsappNo = null;
            employeeHiringClass.LinkedIn = null;
            employeeHiringClass.Twitter = null;
            employeeHiringClass.Instagram = null;
            employeeHiringClass.EnableGarmentAttendance = false;
            employeeHiringClass.TaxAdjustment = null;
            employeeHiringClass.DottedlineReportedTo = null;
            employeeHiringClass.DottedLineReportToRemoteDB = false;
            employeeHiringClass.ReportToEmployeeID = 0;
            employeeHiringClass.SolidLineReportToRemoteDB = false;
            employeeHiringClass.BloodGroup = employeeHiringViewModel.CandidateViewModel.CandidateInfo.Bloodgroup;
            employeeHiringClass.IsColonyResident = false;
            employeeHiringClass.SubDeptID = 0;
            employeeHiringClass.BusRouteID = 0;
            employeeHiringClass.BranchID = employeeHiringViewModel.JobPositionViewModels.BranchId.Value;
            employeeHiringClass.CompanyID = 0;//employeeHiringViewModel.JobPositionViewModels.CompanyId.Value;
            employeeHiringClass.EmployeeGroupID = 0;
            employeeHiringClass.NIC = employeeHiringViewModel.CandidateViewModel.CandidateInfo.CNIC;
            employeeHiringClass.NTN = employeeHiringViewModel.CandidateViewModel.CandidateInfo.NtnNo;
            employeeHiringClass.Passport = employeeHiringViewModel.CandidateViewModel.CandidateInfo.PassportNo;
            employeeHiringClass.Phone = null;
            employeeHiringClass.Mobile = employeeHiringViewModel.CandidateViewModel.CandidateInfo.MobileNo;
            employeeHiringClass.Email = employeeHiringViewModel.UserViewModel.userinfo.UserEmail;
            employeeHiringClass.Address = employeeHiringViewModel.CandidateViewModel.CandidateInfo.PresentAddress;
            employeeHiringClass.Address2 = employeeHiringViewModel.CandidateViewModel.CandidateInfo.CandidateAddress;
            employeeHiringClass.Gender = employeeHiringViewModel.CandidateViewModel.CandidateInfo.Gender;
            employeeHiringClass.MeritalStatus = employeeHiringViewModel.CandidateViewModel.CandidateInfo.MaritalStatus;
            employeeHiringClass.Qualification = 1;//employeeHiringViewModel.CandidateViewModel.CandidateInfo.QualificationId.Value;
            employeeHiringClass.ReligionID = 1;
            employeeHiringClass.DateOfBirth = employeeHiringViewModel.CandidateViewModel.CandidateInfo.DOB ==null?Convert.ToDateTime("1901/01/01"): employeeHiringViewModel.CandidateViewModel.CandidateInfo.DOB.Value;
            employeeHiringClass.DateOfJoining = DateTime.Now;
            employeeHiringClass.cDateOfJoining = DateTime.Now.AddMonths(3);
            employeeHiringClass.PersonalEmail = employeeHiringViewModel.UserViewModel.userinfo.UserEmail;
            employeeHiringClass.ICENumber = "";
            employeeHiringClass.OfficialMobile = employeeHiringViewModel.CandidateViewModel.CandidateInfo.MobileNo;
            employeeHiringClass.WhatsappNo = "";
            employeeHiringClass.LinkedIn = "";
            employeeHiringClass.Twitter = "";
            employeeHiringClass.Instagram = "";
            employeeHiringClass.Facebook = "";
            employeeHiringClass.LanguageID = null;
            employeeHiringClass.ConfirmDate = DateTime.Now;
            if (employeeHiringViewModel.JobApplicationViewModel.Cand_ProfessionalReferences.Count>0)
            {
                employeeHiringClass.Reference1 = employeeHiringViewModel.JobApplicationViewModel.Cand_ProfessionalReferences[0].Refname;
                employeeHiringClass.Ref1Phone = employeeHiringViewModel.JobApplicationViewModel.Cand_ProfessionalReferences[0].RefContact;
                employeeHiringClass.Reference2 = employeeHiringViewModel.JobApplicationViewModel.Cand_ProfessionalReferences[1].Refname;
                employeeHiringClass.Ref2Phone = employeeHiringViewModel.JobApplicationViewModel.Cand_ProfessionalReferences[1].RefContact;
            }
             employeeHiringClass.EmployeeTypeID = 1;
             employeeHiringClass.Salary = Convert.ToInt32(employeeHiringViewModel.IntEvaluationViewModel.CndEvMaster.Salary.Value);
             employeeHiringClass.SpecialAllowanceManagement = 0;
             employeeHiringClass.OffPayroll = 0;
             employeeHiringClass.PayMode = "CASH";
             employeeHiringClass.ChangeOTLimit = false;
             employeeHiringClass.ReplaceOf = null;
             employeeHiringClass.BankID = null;
             employeeHiringClass.AccountNo = null;
             employeeHiringClass.Nationality = employeeHiringViewModel.CandidateViewModel.CandidateInfo.Nationality;
             employeeHiringClass.ConveyanceID = 0;
             employeeHiringClass.OTType = "";
             employeeHiringClass.SimAllowanceID = 0;
             employeeHiringClass.AttAllowance = null;
             employeeHiringClass.SpclAllowance = null;
             employeeHiringClass.EOBINo = employeeHiringViewModel.CandidateViewModel.CandidateInfo.EOBI;
             employeeHiringClass.EOBIDate = null;
             employeeHiringClass.SESSIDate = null;
             employeeHiringClass.TaxNo = 0;
             employeeHiringClass.ShiftID = 0;
             employeeHiringClass.OffDayID = 0;
             employeeHiringClass.isOnJob = true;
             employeeHiringClass.AllowLateComming = false;
             employeeHiringClass.NoAttendance = false;
             employeeHiringClass.NoPayroll = false;
             employeeHiringClass.PhysicalDisablityID = 0;
             employeeHiringClass.EmployeePic = null;
             employeeHiringClass.FamilyCode = null;
             employeeHiringClass.CNICExpire = employeeHiringViewModel.CandidateViewModel.CandidateInfo.ExpiryDate;
             employeeHiringClass.UserID = GlobalUserInfo.UserId;
             employeeHiringClass.EntryDate = DateTime.Now;
             int NewEmpCode = DbEmployeeHiring.Employee_Add(employeeHiringClass, GlobalUserInfo.UserId, CareerGlobalFields.GetConnectionString()) ;
             return NewEmpCode;

        }

    }
}