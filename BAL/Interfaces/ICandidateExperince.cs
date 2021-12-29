using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    interface ICandidateExperince<T>
    {
        
        T GetCandidateExperince(int CndExpId);
        List<T> GetCandidateExperince();
        T AddCandidateExperince(T candExpId);
        int UpdateCandidateExperince(T candExpId);
        
        int DeleteCandidateExp(int CndExpId);
    }
}
