using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using BAL.Interfaces;
using BAL.DbSaveClass;
using DAL;

namespace BAL
{
    public class JobApplied : IjobApply<JobApplyViewModels>
    {
        JobAppyDB jobApplyDb;

        public JobApplied()
        {
            jobApplyDb = new JobAppyDB();

        }
        public bool ApplyJob(JobApplyViewModels Applied)
        {
            CandidateJobApply candidateJobApply = new CandidateJobApply() { 
            Id = Applied.Id,
            AppliedOn = Applied.AppliedOn,
            JobId = Applied.JobId,
            UserId = Applied.UserId,
            ApplyByCV = Applied.ApplyByCV
            
            };


            jobApplyDb.ApplyJob(candidateJobApply);
            return true;
        }

        public bool DeleteApplyJob(JobApplyViewModels Applied)
        {
            throw new NotImplementedException();
        }

        public JobApplyViewModels GetJobApplied(int AppliedId)
        
        {
            var jobApplied = jobApplyDb.GetJobApplied(AppliedId);
            JobApplyViewModels candidateJobApply = new JobApplyViewModels();
            if (jobApplied!=null)
            {


                candidateJobApply.Id = jobApplied.Id;
                candidateJobApply.AppliedOn = jobApplied.AppliedOn;
                candidateJobApply.JobId = jobApplied.JobId;
                candidateJobApply.UserId = jobApplied.UserId;
                candidateJobApply.ApplyByCV = jobApplied.ApplyByCV;

                

            }

            return candidateJobApply;
        }
        public JobApplyViewModels GetJobApplied(int AppliedId,int CandId)

        {
            var jobApplied = jobApplyDb.GetJobApplied(AppliedId, CandId);
            JobApplyViewModels candidateJobApply = new JobApplyViewModels();
            candidateJobApply.CndJobApply = jobApplied;

            return candidateJobApply;
        }

        public List<JobApplyViewModels> GetJobApplied()
        {
            throw new NotImplementedException();
        }

        public bool UpdateApplyJob(JobApplyViewModels Applied)
        {
            throw new NotImplementedException();
        }

        public bool  IsAlreadyApplied(int jobId, int UserId)
        {
            return jobApplyDb.IsAlreadyApplied(jobId, UserId);
        }
    }
}
