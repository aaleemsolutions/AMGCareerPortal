using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ViewModels
{
    public class JobApplyViewModels
    {
        public int Id { get; set; }
        public Nullable<int> JobId { get; set; }
        public Nullable<int> UserId { get; set; }

        public Nullable<bool> ApplyByCV { get; set; }


        public Nullable<System.DateTime> AppliedOn { get; set; }

        public virtual AllPosition AllPosition { get; set; }
        public virtual User User { get; set; }

        public CandidateJobApply CndJobApply { get; set; }
    }
}
