using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class GlobalFields
    {
        public static string UploadDocumentsPath { get; set; }
        public static string ConnectionString { get; set; }

        public static string GetConnectionString(bool GarmentsConnectionString = true, bool CareerPortalCS = false)
        {
            if (GarmentsConnectionString)
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["GarmentsDb"].ToString();
            }
            else
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DenimDb"].ToString();
            }

            return ConnectionString;
        }

    }
}
