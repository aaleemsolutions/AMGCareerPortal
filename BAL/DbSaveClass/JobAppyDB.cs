using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;

namespace BAL.DbSaveClass
{
    internal class JobAppyDB : IjobApply<CandidateJobApply>
    {
        CareerPortalEntities1 dbcontext;
        public JobAppyDB()
        {
            dbcontext = new CareerPortalEntities1();
        }
        public bool ApplyJob(CandidateJobApply JPosition)
        {

            dbcontext.CandidateJobApplies.Add(JPosition);
            dbcontext.SaveChanges();

            return true;
        }

        public bool DeleteApplyJob(CandidateJobApply JPosition)
        {
            dbcontext.CandidateJobApplies.Remove(JPosition);
            dbcontext.SaveChanges();
            return true;
        }

        public CandidateJobApply GetJobApplied(int JobId)
        {
            var getpositions = dbcontext.CandidateJobApplies.Where(m => m.JobId == JobId).FirstOrDefault();

            return getpositions;
        }
        public CandidateJobApply GetJobApplied(int JobId,int UserId)
        {
            var getpositions = dbcontext.CandidateJobApplies.Where(m => m.JobId == JobId && m.UserId == UserId).FirstOrDefault();

            return getpositions;
        }


        public bool UpdateApplyJob(CandidateJobApply JPosition)
        {
            dbcontext.Entry(JPosition).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
            return true;
        }

        List<CandidateJobApply> IjobApply<CandidateJobApply>.GetJobApplied()
        {
            var getpositions = dbcontext.CandidateJobApplies.ToList();

            return getpositions;
        }

        public bool  IsAlreadyApplied(int jobId, int UserId)
        {

            var position = dbcontext.CandidateJobApplies.Where(m => m.JobId == jobId && m.UserId == UserId).FirstOrDefault();

            if (position!=null)
            {
                return true;
            }else
            {
                return false;

            }
        }
    }
}
