using BAL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    class CandidateGeneric : ICandidate<candidate>
    {
        CareerPortalEntities dbcontext;
        public CandidateGeneric()
        {
              dbcontext = new CareerPortalEntities();
        }

        public candidate AddCandidate(candidate Candidate)
        {
            dbcontext.candidates.Add(Candidate);
            dbcontext.SaveChanges();

            return Candidate;
        }

        public int DeleteCandidate(candidate Candidate)
        {
            throw new NotImplementedException();
        }

        public candidate getCandidate(candidate Candidate)
        {
            var getDb = dbcontext.candidates.Where(m => m.Id == Candidate.Id).FirstOrDefault();
            return getDb;
        }

        public candidate getCandidateById(int UserId)
        {
            var getDb = dbcontext.candidates.Where(m => m.Id == UserId).FirstOrDefault();
            return getDb;
        }
        public candidate getCandidate(int UserId)
        {
       

            var dbuser = dbcontext.candidates.Where(m => m.UserId == UserId).FirstOrDefault();
//            var dbuser = dbcontext.candidates.Find(UserId);

            

            return dbuser;
            
        }

        public candidate UpdateCandidate(candidate CandidateUpd)
        {
            //candidate updateCandidate = CandidateUpd;

            var getCandidateDetail= getCandidateById(CandidateUpd.Id);

            dbcontext.Entry(getCandidateDetail).CurrentValues.SetValues(CandidateUpd);
            //dbcontext.Entry(getCandidateDetail).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();

            return CandidateUpd;
        }

        public CandidateQualification GetQualification(int CndQualificationId)
        {


            var dbcndQualification = dbcontext.CandidateQualifications.Where(m => m.id == CndQualificationId).FirstOrDefault();
            

            return dbcndQualification;

        }



    }
}
