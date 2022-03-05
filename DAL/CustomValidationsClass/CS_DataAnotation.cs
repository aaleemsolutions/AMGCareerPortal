using CareerPortal.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomValidationsClass
{
    class CS_DataAnotation
    {

    }
    //[MetadataType(typeof(StudentMetadata))]
    internal sealed class CndEvMasterValidate
    {
        [Required (ErrorMessage ="Kindly select Decision")]
        public Nullable<int> IntEvDecisionId { get; set; }

        [RequiredIf(nameof(IntEvDecisionId), "1", ErrorMessage = "Joining Date Is Required If Candidate Selected")]
        public Nullable<System.DateTime> JoinDate { get; set; }

        [RequiredIf(nameof(IntEvDecisionId), "1", ErrorMessage = "Salary Is Required If Candidate Selected")]
        public Nullable<double> Salary { get; set; }

        [RequiredIf(nameof(IntEvDecisionId), "1", ErrorMessage = "Desination Is Required If Candidate Selected")]
        public Nullable<int> DesignationId { get; set; }

        //[RequiredIf(nameof(IntEvDecisionId), "1", ErrorMessage = "Grade Is Required If Candidate Selected")]
        public Nullable<int> GradeId { get; set; }

        [RequiredIf(nameof(IntEvDecisionId), "1", ErrorMessage = "Department Is Required If Candidate Selected")]
        public Nullable<int> DepartmentId { get; set; }

        
        public string Benifits { get; set; }
    }


    internal sealed class HrShortlistingDetail_Validate
    {
        DAL.cndEvMaster cndEvMasterValidate;
        public HrShortlistingDetail_Validate()
        {
            cndEvMasterValidate = new cndEvMaster();

        }
        public int Id { get; set; }
        //[RequiredIf(nameof(cndEvMasterValidate.IntEvDecisionId), "1",ErrorMessage ="Interview Date Is Required.")]
        public Nullable<System.DateTime> InterviewDate { get; set; }

        //[RequiredIf(nameof(CndEvMasterValidate.IntEvDecisionId), "1", ErrorMessage = "Interview Panel Is Required.")]
        public Nullable<int> PanelId { get; set; }
        //[RequiredIf(nameof(CndEvMasterValidate.IntEvDecisionId), "1", ErrorMessage = "Interview Decision Is Required.")]
        public Nullable<int> DecisionId { get; set; }
        //[RequiredIf(nameof(CndEvMasterValidate.IntEvDecisionId), "1", ErrorMessage = "Interview Time Is Required.")]
        [DisplayFormat(DataFormatString = @"{0:h:\\mm tt}")]
        public DateTime StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }

    
    }
    internal sealed class cndEvDetail_Validate
    {
        [Required (ErrorMessage ="*")]
        public Nullable<int> MapId { get; set; }
    }
    }
