using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Binders;
using DAL;
using ViewModels.Binders;

namespace ViewModels
{
    public class JobApplicationViewModel
    {
        public List<LanguageMaping> LanguageMapings { get; set; }
        public List<Language> Language { get; set; }
        public List<LanguageScore> LanguageScore { get; set; }
        public List<LangScoreType> LanguageType { get; set; }

        public CandidateViewModel CandidateViewModel { get; set; }

        public MoseRecentEmployement MostRecentEmployment { get; set; }

        
        public  ICollection<candidate> candidates { get; set; }
        
        public  ICollection<CandidateJobApply> CandidateJobApplies { get; set; }
        


        [PropertyBinder(typeof(RadioBinders))]
        public List<RadioButtonAnswer> RadioButton { get; set; }



        public Cand_AMPreviousWork Cand_AMPreviousWork { get; set; }

        [PropertyBinder(typeof(Cand_Dependants))]
        public List<Cand_Dependants> Cand_Dependants { get; set; }

        public ICollection<Cand_JobFilledByHr> Cand_JobFilledByHr { get; set; }

        public List<Cand_RelateFreindWorking> Cand_RelateFreindWorking { get; set; }

        public List<CandidateLang> candLang { get; set; }
        public List<Cand_ProfessionalReferences> Cand_ProfessionalReferences { get; set; }

    }
    public class RadioButtonAnswer
    {
        public string name { get; set; }
        public int Answer { get; set; }

    }
}
