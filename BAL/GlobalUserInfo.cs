using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BAL
{
    public static class GlobalUserInfo
    {
        public static string UserName
        {
            get{ return
     
                    HttpContext.Current.Session["UserEmail"].ToString(); 

            }
        }
        public static int UserId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["UserId"]); } 
        }


  


    }
}
