using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;


namespace BAL.CandidateDbSaveClass
{
    internal class CndExpeDbSave : ICandidateExperince<CandidateExperince>
    {
        CareerPortalEntities dbcontext;
        public CndExpeDbSave()
        {
            dbcontext = new CareerPortalEntities();

        }
        public CandidateExperince AddCandidateExperince(CandidateExperince candExpId)
        {
            var dbsave = dbcontext.CandidateExperinces.Add(candExpId);
            dbcontext.SaveChanges();

            return dbsave;
            
        }

        public int DeleteCandidateExp(int CndExpId)
        {
            var cndexp = dbcontext.CandidateExperinces.Where(m => m.id == CndExpId).FirstOrDefault();


        
            dbcontext.CandidateExperinces.Remove(cndexp);
            dbcontext.SaveChanges();

            return CndExpId;
        }

       public List<CandidateExperince> GetCandidateExperince()
        {
            var CndExperince = dbcontext.CandidateExperinces.ToList();


            return CndExperince;
        }
        public CandidateExperince GetCandidateExperince(int CndExpId)
        {
            var CndExperince = dbcontext.CandidateExperinces.Where(m => m.id == CndExpId).FirstOrDefault();
          

            return CndExperince;
        }

        public int UpdateCandidateExperince(CandidateExperince candExpId)
        {
            var CandExp = candExpId;

            //dbcontext.Entry(CandidateQual).CurrentValues.SetValues(CandidateQual);
            dbcontext.Entry(CandExp).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();

            return 1;
        }

       
    }
}
