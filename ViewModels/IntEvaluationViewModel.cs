using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ViewModels
{
   public class IntEvaluationViewModel
    {
        public IntEvaluationViewModel()
        {
            CandShortListViewModel = new CandShortListViewModel();
            //cndEvDetails = new List<cndEvDetail>();
        }
        public IntScoreType IntScoreType{ get; set; }
        public List<IntEvaluationType> intEvaluationTypes { get; set; }
        public List<IntEvQuestion> intEvQuestions { get; set; }
        public List<IntQuestionMapping> intQuestionMappings { get; set; }

        public DAL.cndEvMaster CndEvMaster { get; set; }

        public List<DAL.cndEvDetail> cndEvDetails { get; set; }

        public List<DAL.IntEvDecision> intEvDecisions { get; set; }
        public ViewModels.CandShortListViewModel CandShortListViewModel { get; set; }

        public UserViewModel userViewModel { get; set; }

        public CandidateViewModel CandidateViewModel{ get; set; }


    }
}
