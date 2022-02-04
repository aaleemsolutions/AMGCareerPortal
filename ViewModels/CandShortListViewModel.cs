using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL;


namespace ViewModels
{
    public class CandShortListViewModel
    {
        public CandShortListViewModel()
        {

        }

        public  HrShortlisting HrShortlisting { get; set; }
        public List<TimingSlot> timingSlots{ get; set; }
        public JobApplyViewModels jobApplyViewModels { get; set; }

        public bool IsEmailSend { get; set; } = true;
        public bool IsSendJobForm { get; set; } = true;

        [AllowHtml]
        public string ShortListEmailBody { get; set; }

    }
}
