using System.Web.Mvc;

namespace CareerPortal.Areas.CandidatePortal
{
    public class CandidatePortalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CandidatePortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CandidatePortal_default",
                "CandidatePortal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}