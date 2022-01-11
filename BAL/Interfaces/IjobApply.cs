using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
   internal interface IjobApply<T>
    {

        
        T GetJobApplied(int AppliedId);
        List<T> GetJobApplied();
        bool ApplyJob(T Applied);
        bool UpdateApplyJob(T Applied);
        bool DeleteApplyJob(T Applied);

        bool IsAlreadyApplied(int jobId,int UserId);
    }
}
