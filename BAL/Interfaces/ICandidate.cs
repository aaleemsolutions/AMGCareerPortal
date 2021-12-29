using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    interface ICandidate<T>
    {
        T getCandidate(T Candidate);
        T getCandidate(int UserId);
        T AddCandidate(T Candidate);
        T UpdateCandidate(T CandidateUpd);
        int DeleteCandidate(T Candidate);
        
        
    }
}
