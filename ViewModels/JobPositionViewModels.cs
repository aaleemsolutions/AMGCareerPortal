using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BAL.Binders;
using DAL;
using ViewModels.Binders;



namespace ViewModels
{
    public class JobPositionViewModels
    {

        public int JobId { get; set; } = 0;

        public bool IsAlreadyApplied { get; set; } = false;
        public Nullable<bool> AppliedBYCV { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string JobLocation { get; set; } = "Karachi";
        public Nullable<System.DateTime> PostedDate { get; set; } = DateTime.Now;
        public Nullable<long> JobTotalViews { get; set; }
        [AllowHtml]
        [Required (ErrorMessage = "Job Description is required.")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Please mention No Of Vacancy ")]

        public Nullable<int> NoOfVacancy { get; set; } = 1;
        public Nullable<bool> IsPositionOpen { get; set; }
        public string EmployementType { get; set; } = "Permanant";
        public string SalaryRange { get; set; } = "0";
        public Nullable<int> GenderSpecification { get; set; } = 0;
        public Nullable<int> MinExperinceYear { get; set; } = 0;
        public Nullable<System.DateTime> LastDateOfJob { get; set; } = null;
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        [Required]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        [Required]
        public Nullable<int> DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        [Required]
        public Nullable<int> DesignationId { get; set; }
        public string DesignationName { get; set; }
        [Required]
        public Nullable<int> CategoryId { get; set; }
        public string CategoryName { get; set; }


        public AllPosition JobPositions { get; set; }
        public virtual ICollection<CandidateJobApply> CandidateJobApplies { get; set; }

        public List<AllPosition> ListAlljobs { get; set; }




    }


    public class PositionListViewModel
    {
        List<JobPositionViewModels> ListJobs = new List<JobPositionViewModels>();
        



    }

}
