using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using DAL;

namespace ViewModels
{
   public  class InterviewPanelViewModel
    {
        public InterviewPerson InterviewPerson { get; set; }
        public InterviewPanel InterviewPanels { get; set; }
        public List<InterviewPanelDetail> InterviewPanelDetail { get; set; }
        
    }
}
