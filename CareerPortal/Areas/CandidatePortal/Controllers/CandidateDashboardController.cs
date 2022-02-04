using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ViewModels;


namespace CareerPortal.Areas.CandidatePortal.Controllers
{
    [Authorize]
    public class CandidateDashboardController : Controller
    {
        // GET: CandidatePortal/CandidateDashboard
        CandidateLogics candidateobj;

        GetUserDetails getusrDetail;

        UserRegModule RegUser; 

        //HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];//Request.Cookies[FormsAuthentication.FormsCookieName];
        //FormsAuthenticationTicket ticketInfo = FormsAuthentication.Decrypt(cookie.Value); //FormsAuthentication.Decrypt(cookie.Value);

        public int UserId;
        public int CandidateId;
        private string Username;


        public CandidateDashboardController()
        {
            candidateobj = new CandidateLogics();
            getusrDetail = new GetUserDetails();
            RegUser = new UserRegModule();

            if (System.Web.HttpContext.Current.Session["UserId"]!=null)
            {
                var test = System.Web.HttpContext.Current.Session["UserId"];
                UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString());
                Username = System.Web.HttpContext.Current.Session["UserEmail"].ToString();

            }
            else
            {
                FormsAuthentication.SignOut();
                
            }

            var dbobj = candidateobj.getCandidate(GlobalUserInfo.UserId);

            if (dbobj.UsersInfo!=null)
            {
                if (dbobj.UsersInfo.CandidateJobApplies.Where(m => m.HrShortlistings.Count > 0).Count() > 0)
                {
                    GlobalUserInfo.JobApplicationOpen = true;


                }
                if (dbobj.UsersInfo != null)
                {
                    GlobalUserInfo.EmailAddress = dbobj.UsersInfo.UserEmail;
                    GlobalUserInfo.FullName = dbobj.UsersInfo.FullName;


                }
            }
        



        }

        public ActionResult Index()
        {

            var dbuser = RegUser.getUser(GlobalUserInfo.UserName);

            var dbobj = candidateobj.getCandidate(GlobalUserInfo.UserId);
            CandidateId = dbobj.CandidateId.HasValue==true?dbobj.CandidateId.Value:0;

            dbobj.EmailVerifyMessage = dbuser.userinfo.IsEmailVerify.Value;
       
            if (dbobj.CandidateInfo!=null)
            {
                if (dbobj.CandidateInfo.User != null)
                {
                    if (dbobj.CandidateInfo.User.UserImage != null)
                    {
                        dbobj.UserDbImagebase64 = dbobj.CandidateInfo.User.UserImage.ToString();
                    }
                    
                }

                Session["UserImage"] = dbobj.UserDbImagebase64;
            }
           

            var GetAllDegrees = new SelectList(getusrDetail.GetAllDegrees().ToList(), "Qualification_ID", "Qualification_Name").ToList();
            GetAllDegrees.Insert(0, (new SelectListItem { Text = "Select Degree", Value = "0" }));
            ViewBag.DegreeDropDown = GetAllDegrees;
            //ViewBag.DegreeDropDown = getusrDetail.GetAllDegrees().ToList();

            List<SelectListItem> MonthNameDropDown = GetMonthsName.ToList();
            MonthNameDropDown.Insert(0, (new SelectListItem { Text = "Select Month", Value = "0" }));
            ViewBag.MonthNameDropdown = MonthNameDropDown.ToList();

            List<SelectListItem> YearDropdown = new SelectList(Enumerable.Range(1960, (DateTime.Now.Year - 1960) + 1)).ToList();
            YearDropdown = YearDropdown.Select(m => new SelectListItem { Text = m.Text, Value = m.Text }).ToList();
            YearDropdown.Insert(0, (new SelectListItem { Text = "Select Year", Value = "0" }));
            ViewBag.YearDropdown = YearDropdown.ToList().OrderByDescending(m => m.Text);

            ViewBag.GradeTypes = GradeTypes().ToList();


            return View(dbobj);
        }


        [HttpPost]
        [ActionName("Index")]
        public JsonResult CandidateDashboard(CandidateViewModel candidateViewModel , string FormWizardSteps ,string DegreeName , CndQualificationViewModel cndQualificationViewModel ,CndExperienceViewModel CndExperienceViewModel )
        {
            bool formvalidate = false;

            try
            {
                int UserID = Convert.ToInt32(UserId);
                var CheckCandidateId = candidateobj.getCandidate(UserID);

                CandidateId = CheckCandidateId.CandidateInfo!=null? CheckCandidateId.CandidateInfo.Id:0;

                if (FormWizardSteps == "0")
                {
                    if (CheckCandidateId.CandidateInfo != null)
                    {
                        candidateViewModel.CandidateInfo = CheckCandidateId.CandidateInfo;
                           candidateobj.UpdateCandidate(candidateViewModel);
                    }
                    else
                    {
                        candidateobj.AddCandidate(candidateViewModel);
                    }
                    formvalidate = true;
                }
                else if (FormWizardSteps == "1")
                {
                    if (cndQualificationViewModel != null && candidateViewModel.CndQualificationViewModel == null)
                    {

                        candidateViewModel.CndQualificationViewModel = cndQualificationViewModel;

                    }
                    if (candidateViewModel.CndQualificationViewModel.id!=0)
                    {
                       
                        candidateViewModel.CndQualificationViewModel.CandidateId = CandidateId;
                        candidateViewModel.CndQualificationViewModel.DegreeName = DegreeName;
                        candidateobj.UpdateCandidateQualification(candidateViewModel);

                    }
                    else
                    {
                        candidateViewModel.CndQualificationViewModel.CandidateId = CandidateId;
                        candidateViewModel.CndQualificationViewModel.DegreeName = DegreeName;
                        candidateobj.AddCandidateQualification(candidateViewModel);

                    }


                    formvalidate = true;


                }
                else if (FormWizardSteps == "2")
                {
                    if (CndExperienceViewModel != null && candidateViewModel.CndExperienceViewModel == null)
                    {

                        candidateViewModel.CndExperienceViewModel = CndExperienceViewModel;
                        
                    }
                    if (candidateViewModel.CndExperienceViewModel.id != 0)
                    {
                        candidateViewModel.CndExperienceViewModel.CandidateId = CandidateId;

                        //if (candidateViewModel.JobDutiesDescription==null && JobDutiesDescription!=null)
                        //{
                        //    candidateViewModel.CndExperienceViewModel.JobDuties = JobDutiesDescription;

                        //}
                        if (candidateViewModel.JobDutiesDescription == null )
                        {
//                            candidateViewModel.CndExperienceViewModel.JobDuties = candidateViewModel.JobDutiesDescription;

                        }
                        else
                        {
                           // candidateViewModel.CndExperienceViewModel.JobDuties = candidateViewModel.JobDutiesDescription;
                        }
                        
                        candidateobj.UpdateCandidateExperince(candidateViewModel);

                    }
                    else
                    {
                        candidateViewModel.CndExperienceViewModel.CandidateId = CandidateId;
                        candidateViewModel.CndExperienceViewModel.JobDuties = candidateViewModel.JobDutiesDescription;
                        candidateobj.AddCandidateExperince(candidateViewModel);

                    }


                    formvalidate = true;


                }

            }
            catch (Exception ex)
            {
                formvalidate = false;
                throw;
            }


            return Json(new { Validateform = formvalidate }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetCandidateQualification()
        {

            var getCndQual = candidateobj.getCandidate(UserId);
             
            if (getCndQual.CandidateInfo != null)
            {
               var cndQualification = getCndQual.CandidateInfo.CandidateQualifications.ToList().Select(m => new
                {
                    QualificationId = m.id,
                    InstitutionName = m.InstitutionName,
                    Specialization = m.Specialization,
                    DegreeId = m.DegreeName,
                    FromMonth = new DateTime(m.DgrFrmYear.Value, m.DgrFrmMonth.Value, 1).ToString("MMM-yyyy"),
                    //toMonth = cndQualification.Select(m => m.DgrToYear.HasValue ==false? "-" : new DateTime(m.DgrToYear.Value, m.DgrToYear.Value, 1).ToString("MMM-yyyy")),
                    toMonth = m.DgrToYear == null ? " - " : new DateTime(m.DgrToYear.Value, m.DgrToMonth.Value, 1).ToString("MMM-yyyy"),

                    ResultType = m.ResultType + " - " + m.ResultValue
                });
                return Json(new { data = cndQualification }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);

            }
 

            

            
        }


        public JsonResult GetCandidateExperience()
        {

            var getCndQual = candidateobj.getCandidate(UserId);

            if (getCndQual.CandidateInfo!=null)
            {
                var cndExperience = getCndQual.CandidateInfo.CandidateExperinces.ToList().Select(m => new {
                    ExperienceId = m.id,
                    CompanyName = m.CompanyName,
                    DesignationName = m.DesignationName,
                    LocationName = m.Locationname,
                    FromMonth = (m.FromYear == null || m.FromYear == 0) ? "-" : new DateTime(m.FromYear.Value, m.FromMonth.Value, 1).ToString("MMM-yyyy"),
                    //toMonth = cndQualification.Select(m => m.DgrToYear.HasValue ==false? "-" : new DateTime(m.DgrToYear.Value, m.DgrToYear.Value, 1).ToString("MMM-yyyy")),
                    toMonth = (m.ToYear == null || m.ToYear == 0) ? " - " : new DateTime(m.ToYear.Value, m.ToMonth.Value, 1).ToString("MMM-yyyy"),

                    ReasonForLeaving = m.ReasonForLeaving,
                    CurrentSalary = m.CurrentSalary
                });



                return Json(new { data = cndExperience }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
            }
         
        }


        public JsonResult GetCndQualificationById(int Qualificationid)
        {

            var getCndQual = candidateobj.GetQualification(Qualificationid);

            var cndQualification = new
            {
                QualificationId = getCndQual.id,
                InstitutionName = getCndQual.InstitutionName,
                Specialization = getCndQual.Specialization,
                DegreeId = getCndQual.DegreeId,
                FromMonth = getCndQual.DgrFrmMonth,
                fromYear = getCndQual.DgrFrmYear,
                ToMonth = getCndQual.DgrToMonth,
                ToYear = getCndQual.DgrToYear,
                //FromMonth = new DateTime(getCndQual.DgrFrmYear.Value, getCndQual.DgrFrmMonth.Value, 1).ToString("MMM-yyyy"),
                //toMonth = cndQualification.Select(m => m.DgrToYear.HasValue ==false? "-" : new DateTime(m.DgrToYear.Value, m.DgrToYear.Value, 1).ToString("MMM-yyyy")),
                //toMonth =       getCndQual.DgrToYear==null ? "-" : new DateTime(getCndQual.DgrFrmYear.Value, getCndQual.DgrFrmMonth.Value, 1).ToString("MMM-yyyy"),

                ResultType = getCndQual.ResultType,
                ResultValue = getCndQual.ResultValue,
                IsOnGoing = getCndQual.isOngoing
            };

       
            


            return Json(new { data = cndQualification }, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetCndExperienceById(int ExperinceID)
        {

            var getCndQual = candidateobj.getCandidateExperinceById(ExperinceID);

            var CndExperience = new
            {
                ExperienceId = getCndQual.id,
                CompanyName = getCndQual.CompanyName,
                DesignationName = getCndQual.DesignationName,
                LocationName = getCndQual.Locationname,
                FromMonth = getCndQual.FromMonth,
                fromYear = getCndQual.FromYear,
                ToMonth = getCndQual.ToMonth,
                ToYear = getCndQual.ToYear,
                ReasonForLeaving = getCndQual.ReasonForLeaving,
                CurrentSalary = getCndQual.CurrentSalary,
                FreshGraduate = getCndQual.FreshGraduate,
                IsPresent = getCndQual.IsPresent,
                JobDuties = getCndQual.JobDuties
                


            };





            return Json(new { data = CndExperience }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateQualification()
        {

            var getCndQual = candidateobj.getCandidate(UserId);


            var cndQualification = getCndQual.CandidateInfo.CandidateQualifications.ToList().Select(m => new {
                QualificationId = m.id,
                InstitutionName = m.InstitutionName,
                Specialization = m.Specialization,
                DegreeId = m.DegreeId,
                FromMonth = new DateTime(m.DgrFrmYear.Value, m.DgrFrmMonth.Value, 1).ToString("MMM-yyyy"),
                //toMonth = cndQualification.Select(m => m.DgrToYear.HasValue ==false? "-" : new DateTime(m.DgrToYear.Value, m.DgrToYear.Value, 1).ToString("MMM-yyyy")),
                toMonth = m.DgrToYear,

                ResultType = m.ResultType
            });



            return Json(new { data = cndQualification }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteCandidateExperince(int Id)
        {


            try
            {

                candidateobj.DeleteCandidateExperince(Id);
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {


                return Json(false, JsonRequestBehavior.AllowGet);

            }




        }
        public JsonResult DeleteQualification(int Id)
        {


            try
            {

                candidateobj.DeleteCandidateQualification(Id);
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {


                return Json(false, JsonRequestBehavior.AllowGet);
                
            }



        }
        public IEnumerable<SelectListItem> GetMonthsName
        {
            get
            {
                return DateTimeFormatInfo
                       .InvariantInfo
                       .MonthNames
                       .Select((monthName, index) => new SelectListItem
                       {

                           Value = (index + 1).ToString(),
                           Text = monthName
                       });
            }
        }
        public SelectList GradeTypes()
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select Grade" });
            _list.Insert(1, new SelectListItem() { Value = "Grade", Text = "Grade" });
            _list.Insert(2, new SelectListItem() { Value = "CGPA", Text = "CGPA" });
            _list.Insert(3, new SelectListItem() { Value = "Perecentage", Text = "Percentage" });
            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
        }
        public IEnumerable<SelectListItem> GetYearName
        {
            get
            {
                return DateTimeFormatInfo
                       .InvariantInfo
                       .MonthNames
                       .Select((monthName, index) => new SelectListItem
                       {

                           Value = (index + 1).ToString(),
                           Text = monthName
                       });
            }
        }


    }
}