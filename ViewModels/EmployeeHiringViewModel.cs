using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace ViewModels
{
    public class EmployeeHiringViewModel
    {

        public CandidateViewModel CandidateViewModel { get; set; }

        public IntEvaluationViewModel IntEvaluationViewModel { get; set; }
        public CandShortListViewModel CandShortListViewModel { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public JobApplicationViewModel JobApplicationViewModel { get; set; }
        public JobPositionViewModels JobPositionViewModels { get; set; }

        public EmployeeHiringViewModel()
        {
            CandidateViewModel = new CandidateViewModel();
            IntEvaluationViewModel = new IntEvaluationViewModel();
            CandShortListViewModel = new CandShortListViewModel();
            UserViewModel = new UserViewModel();
            JobApplicationViewModel = new JobApplicationViewModel();
            JobPositionViewModels = new JobPositionViewModels();
        }

    }
}
