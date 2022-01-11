using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using BAL.Utilities;

namespace CareerPortal.Areas.CandidatePortal.Controllers
{
    public class CandidatejobController : Controller
    {
        // GET: CandidatePortal/Candidatejob

        JobAllPositions JobPos;
        UserRegModule RegUser;
        JobApplied JobApplied;
        public CandidatejobController()
        {
            JobPos = new JobAllPositions();
            RegUser = new UserRegModule();
            JobApplied = new JobApplied();
        }
        public ActionResult Index()
        {

            var db = JobPos.GetAllPositionsInViewModel();

            return View(db);
        }

        public ActionResult JObDetailPartial(int JobId)
        {
            var GetJob = JobPos.GetPosition(JobId);

            GetJob.IsAlreadyApplied = JobApplied.IsAlreadyApplied(JobId, GlobalUserInfo.UserId);
            GetJob.AppliedBYCV = JobApplied.GetJobApplied(JobId).ApplyByCV;

            return PartialView("~/Areas/CandidatePortal/Views/Shared/_JobDetailPartial.cshtml", GetJob);
        }
        public ActionResult UploadCandidateCv(HttpPostedFileBase CandidateCvProfile )
        {
            try
            {

                if (CandidateCvProfile != null)
                {
                    string filename = "CV_" + GlobalUserInfo.UserName.Trim() + GlobalUserInfo.UserId.ToString() + "_" + DateTime.Now.ToString("ddMMyy_hhmm") + Path.GetExtension(CandidateCvProfile.FileName);
                    ImageSaving.savePostedFileIntoFolder(CandidateCvProfile, GlobalFields.UploadDocumentsPath, filename);
                    var user = RegUser.getUser(GlobalUserInfo.UserId);
                    user.userinfo.CandidateCVPath = GlobalFields.UploadDocumentsPath + filename;
                    user.userinfo.CVUpdatedOn = DateTime.Now;
                    RegUser.UpdateUser(user);

                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult GetCandidateCv(HttpPostedFileBase CandidateCvProfile)
        {
            try
            {

                var user = RegUser.getUser(GlobalUserInfo.UserId);
                string CvPath = "";
                string filename = "";
                long filesize =0;
                if (user.userinfo!=null)
                {
                    CvPath = Server.MapPath(user.userinfo.CandidateCVPath);
                    string fileext = CvPath.Substring(CvPath.LastIndexOf('.'));
                    filename = "CV_UpdatedOn"+user.userinfo.CVUpdatedOn.Value.ToString("dd-MMM-yyyy")+fileext;

                    FileInfo fi = new FileInfo(CvPath);
                    filesize = fi.Length  ;

                }
                

                return Json(new { name = filename, path = CvPath, size = filesize.ToString() }, JsonRequestBehavior.AllowGet);

             //return Json(new { name = "CV_Abdul Aleem1_171221_0226.pdf", path  = @"F:\AbdulAleem\MyWorkingFolder\WebProjects\CareerPortal\CareerPortal\CareerPortal\UploadedDocuments\UploadedCV\CV_Abdul Aleem1_171221_0226.pdf", size  ="1024"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult DeleteCandidateCv(HttpPostedFileBase CandidateCvProfile)
        {
            try
            {

                var user = RegUser.getUser(GlobalUserInfo.UserId);
                user.userinfo.CandidateCVPath = "";
                string CvPath = Server.MapPath(user.userinfo.CandidateCVPath);
                if (System.IO.File.Exists(CvPath))
                {
                    System.IO.File.Delete(CvPath);
                }
                RegUser.UpdateUser(user);
                return Json(true, JsonRequestBehavior.AllowGet);

                //return Json(new { name = "CV_Abdul Aleem1_171221_0226.pdf", path  = @"F:\AbdulAleem\MyWorkingFolder\WebProjects\CareerPortal\CareerPortal\CareerPortal\UploadedDocuments\UploadedCV\CV_Abdul Aleem1_171221_0226.pdf", size  ="1024"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult ApplyForJob(int JobId,bool AppliedByCv)
        {
            try
            {
                var user = RegUser.getUser(GlobalUserInfo.UserId);
                if (AppliedByCv == true)
                {
                    if (user.userinfo.CandidateCVPath == null || user.userinfo.CandidateCVPath == "")
                    {
                        return Json(new { IsSuccess = false,msg = "Please Upload CV First."}, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ViewModels.JobApplyViewModels jbApplyViewModels = new ViewModels.JobApplyViewModels()
                        {
                            AppliedOn = DateTime.Now,
                            JobId = JobId,
                            UserId = GlobalUserInfo.UserId,
                            ApplyByCV = AppliedByCv


                        };

                        JobApplied.ApplyJob(jbApplyViewModels);
                    }

                }
                else
                {
                    ViewModels.JobApplyViewModels jbApplyViewModels = new ViewModels.JobApplyViewModels()
                    {
                        AppliedOn = DateTime.Now,
                        JobId = JobId,
                        UserId = GlobalUserInfo.UserId,
                        ApplyByCV = AppliedByCv


                    };
                    JobApplied.ApplyJob(jbApplyViewModels);
                }
             


           
                
        



                return Json(new { IsSuccess = true, msg = "Successfully Applied." }, JsonRequestBehavior.AllowGet);

                //return Json(new { name = "CV_Abdul Aleem1_171221_0226.pdf", path  = @"F:\AbdulAleem\MyWorkingFolder\WebProjects\CareerPortal\CareerPortal\CareerPortal\UploadedDocuments\UploadedCV\CV_Abdul Aleem1_171221_0226.pdf", size  ="1024"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { IsSuccess = false, msg = ex.Message}, JsonRequestBehavior.AllowGet);
            }

        }






        public ActionResult DownloadCandidateCv(string Filename ,int UserId = 0)
        {

            string currentUrl = Request.UrlReferrer.ToString();

            var user = RegUser.getUser(GlobalUserInfo.UserId);


            if (UserId!=0)
            {
            user = RegUser.getUser(UserId);

            }

            string CvPath = Server.MapPath(user.userinfo.CandidateCVPath);
            FileInfo fi = new FileInfo(CvPath);
            byte[] fileBytes ;

            if (System.IO.File.Exists(CvPath))
            {
                 fileBytes = System.IO.File.ReadAllBytes(CvPath);
                string fileName = "ArtisticMilliners_UploadedCV" + fi.Extension;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            return Redirect(currentUrl);
        }

    }
}