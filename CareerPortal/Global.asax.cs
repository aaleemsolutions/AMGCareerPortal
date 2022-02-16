using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using BAL;
using CareerPortal.Controllers;

namespace CareerPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
      
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
         

            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

         

        }
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string DocumentsUploaded = ConfigurationManager.AppSettings["CVUploadPath"].ToString();

            GlobalFields.UploadDocumentsPath = DocumentsUploaded;



        }


        void Session_Start(object sender, EventArgs e)
        {

            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");


            if (Session["UserId"] == null)
            {
                FormsAuthentication.SignOut();
               // Response.Redirect("~/Account/Login");
            }
        }
        protected void Application_Error()
        {
         
           

            if (GlobalUserInfo.UserId ==0)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/Home/Index");
            }
            //log an exception
        }

        //protected void Application_AcquireRequestState(Object sender, EventArgs e)
        //{
        //    if (Session["UserId"]==null)
        //    {
        //        FormsAuthentication.SignOut();
        //        //Response.Redirect("~/Account/Login");
        //    }

        //}
    }
}
