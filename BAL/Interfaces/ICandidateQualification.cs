using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    interface ICandidateQualification<T>
    {
        
        T getCandidateQualification(int UserId);
        T AddCandidateQualification(T Candidate);
        T UpdateCandidateQualification(T CandidateUpd);
        int DeleteCandidateQualification(T Candidate);


    }
}
