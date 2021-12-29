using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL;

namespace ViewModels
{
    public class CndExperienceViewModel
    {
        public  CandidateExperince CndExperience { get; set; }


        public int id { get; set; }
        public Nullable<int> CandidateId { get; set; }
        public string CompanyName { get; set; } = "";
        public string DesignationName { get; set; } = "";
        public string Locationname { get; set; } = "";
        public int FromMonth { get; set; } = 0;
        public int FromYear { get; set; } = 0;
        public int ToMonth { get; set; } = 0;
        public int ToYear { get; set; } = 0;
        public bool IsPresent { get; set; } = false;

        public bool FreshGraduate { get; set; } = false;
        public string ReasonForLeaving { get; set; } = "";
        public decimal InitialSalary { get; set; } = 0;
        public decimal CurrentSalary { get; set; } = 0;
        [AllowHtml]
        public string JobDuties { get; set; } = "";


    }
}
