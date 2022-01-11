using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerPortal.App_Code
{
    public class HelloWorldModule
    {

        public HelloWorldModule()
        {
        }

        public String ModuleName
        {
            get { return "HelloWorldModule"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));
        }

        private void Application_BeginRequest(Object source,
             EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            
                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
             
        }

        public void Dispose() { }

    }
}