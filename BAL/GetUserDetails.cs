using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BAL
{
    public class GetUserDetails
    {
        CareerPortalEntities dbcontext;
        public GetUserDetails()
        {
            dbcontext = new CareerPortalEntities();

        }

        public List<DAL.usp_getallDegree_Result> GetAllDegrees()
        {

            return dbcontext.usp_getallDegree().ToList();
        }


    

    }
}
