using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ViewModels
{
    public class CndQualificationViewModel
    {
        public CandidateQualification CndQualification { get; set; }

        public int id { get; set; }


        public Nullable<int> CandidateId { get; set; }
        public string InstitutionName { get; set; }
        public string DegreeName { get; set; }
        public Nullable<int> DegreeId { get; set; }
        public string Specialization { get; set; }
        public Nullable<int> DgrFrmMonth { get; set; }
        public Nullable<int> DgrFrmYear { get; set; }
        public Nullable<int> DgrToMonth { get; set; }
        public Nullable<int> DgrToYear { get; set; }
        public bool isOngoing { get; set; }
        public Nullable<int> ResultTypeId { get; set; }
        public string ResultType { get; set; }
        public string ResultValue { get; set; }

        

    }
}
