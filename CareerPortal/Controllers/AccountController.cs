using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using BAL;
using System.Web.Security;
using BAL.Utilities;
using BAL.PasswordCoder;

namespace CareerPortal.Controllers
{
    public class AccountController : Controller
    {
        UserRegModule RegUser;
        public AccountController()
        {
            RegUser = new UserRegModule();
        }

        // GET: Account
        public ActionResult RegisterUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(UserViewModel userInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegUser.AddUser(userInfo);
                 

                    TempData["UserRegister"] = true;
                    TempData["UserName"] = userInfo.UserEmail;
                    TempData["UserPassword"] = userInfo.UserPassword;
                    userInfo = null;
                    return RedirectToAction("Login");
                }
                else
                {
                    return View(userInfo);
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Login");
                // throw ex;
            }


        }

            public ActionResult Login(string returnUrl)
        {
            if (TempData["UserRegister"]!=null)
            {
                string Password = TempData["UserPassword"].ToString();
                string Username = TempData["UserName"].ToString();
                if (Username !=null && Password !=null)
                {
                    UserloginViewModel user = new UserloginViewModel();
                    user.Emailaddress = Username;
                    user.Password = Password;
                    TempData["UserRegister"] = null;
                    return Login(user, "");
                }
                
            }
            
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "CandidateDashboard", new { area = "CandidatePortal" });

            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
      
        }

        [HttpPost]
        public ActionResult Login(UserloginViewModel userviewModel, string returnUrl = "")
        {
            try
            {
                var checkUser = RegUser.ValidateUser(userviewModel.Emailaddress, userviewModel.Password);

                if (checkUser.userinfo!=null)
                {



                    Session["UserId"] = checkUser.userinfo.Id;
                    Session["UserEmail"] = checkUser.userinfo.UserEmail;
                   

                    string userData = checkUser.userinfo.Id.ToString();
                    var authTicket = new FormsAuthenticationTicket(
                                                     1,
                                                     checkUser.userinfo.UserEmail,  //user id
                                                     DateTime.Now,
                                                     DateTime.Now.AddMinutes(20),  // expiry
                                                     userviewModel.Remembme,  //true to remember
                                                     userData, //roles 
                                                     "/"
                                                     );

                    //encrypt the ticket and add it to a cookie
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);

                    string decodereturnUrl = "";
                    if (!string.IsNullOrEmpty(returnUrl))
                        decodereturnUrl = Server.UrlDecode(returnUrl);

                    if (Url.IsLocalUrl(decodereturnUrl))
                    {
                        return Redirect(decodereturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "CandidateDashboard", new { area = "CandidatePortal" });
                    }

            
                    

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username/Password");
                    return View(userviewModel);

                }

     
                

       

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error While Sending Your Request.");

            }


            return View(userviewModel);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult VerifyEmail(string Token, string Email)
        {

            try
            {
                var dbresult = RegUser.UpdateEmailTokenn(Token, Email);

            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("Login");

        }



        public JsonResult ResendVerifyAccountEmail()
        {
            string UserEmail = Session["UserEmail"].ToString();

            try
            {
                string NewEmailToken = SecurePasswordEncryption.GenerateEmailsToken();
                var dbuser = RegUser.getUser(UserEmail);

                dbuser.userinfo.EmailTokens = NewEmailToken;

                RegUser.UpdateUser(dbuser);
                

                SendEmail.Email(SendEmail.AccountOpeningEmail(NewEmailToken, UserEmail), "Artistic Milliners - Verify Job Portal Account", UserEmail);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                

                return Json(false,JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult UsernameExists(string UserEmail)
        {

            var test = RegUser.IsUserExist(UserEmail);
            if (test !=null)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
            
        }


    }
}