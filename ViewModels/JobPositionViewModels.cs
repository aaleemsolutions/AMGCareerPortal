using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace ViewModels
{
    public class JobPositionViewModels
    {

        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public Nullable<System.DateTime> PostedDate { get; set; }
        public Nullable<long> JobTotalViews { get; set; }
        public string JobDescription { get; set; }
        public Nullable<int> NoOfVacancy { get; set; }
        public Nullable<bool> IsPositionOpen { get; set; }
        public string EmployementType { get; set; }
        public string SalaryRange { get; set; }
        public Nullable<int> GenderSpecification { get; set; }
        public Nullable<int> MinExperinceYear { get; set; }
        public Nullable<System.DateTime> LastDateOfJob { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }


        public AllPosition JobPositions { get; set; }
    }
}
