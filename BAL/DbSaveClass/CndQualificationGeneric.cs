using BAL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class CndQualificationGeneric : ICandidateQualification<CandidateQualification>
    {
        CareerPortalEntities dbcontext;

        public CndQualificationGeneric()
        {
            dbcontext = new CareerPortalEntities();
        }

        public CandidateQualification AddCandidateQualification(CandidateQualification Candidatequal)
        {

            dbcontext.CandidateQualifications.Add(Candidatequal);
            dbcontext.SaveChanges();

            return Candidatequal;
        }



        public CandidateQualification UpdateCandidateQualification(CandidateQualification Candidatequal)
        {

            var CandidateQual = Candidatequal;

            //dbcontext.Entry(CandidateQual).CurrentValues.SetValues(CandidateQual);
            dbcontext.Entry(Candidatequal).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();

            return CandidateQual;

       
 
        }

        public int DeleteCandidateQualification(CandidateQualification Candidate)
        {
           
            dbcontext.CandidateQualifications.Remove(Candidate);
            dbcontext.SaveChanges();

            return Candidate.id;
        }


        public int DeleteCandidateQualification(int QualificationId)
        {

            var Cndqual = dbcontext.CandidateQualifications.Where(m=>m.id == QualificationId).FirstOrDefault();


            dbcontext.CandidateQualifications.Remove(Cndqual);
            dbcontext.SaveChanges();

            return QualificationId;
        }
        public CandidateQualification getCandidateQualification(int UserId)
        {
            throw new NotImplementedException();
        }

      
    }
}
