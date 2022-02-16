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
            get
            {
                try
                {
                    return HttpContext.Current.Session["UserEmail"].ToString();
                }
                catch
                {
                    return "";

                }


               

            }
        }
        public static int UserId
        {
            get
            {

                try
                {
                    return Convert.ToInt32(HttpContext.Current.Session["UserId"]);

                }
                catch (Exception)
                {
                    return 0;

                }


                    ;

            }
        }


        public static bool JobApplicationOpen
        { get; set; } = false;
        public static bool IsSideBarOpen { get {
                return Convert.ToBoolean(HttpContext.Current.Request.Cookies["IsSideBarOpen"].Value);
            }
     
        } 

        public static string FullName { get; set; }
        public static string EmailAddress { get; set; }


        public static bool IsUserIdnull { get; set; } = (UserId == 0 ? false : true);




    }
}
