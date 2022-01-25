using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;

namespace BAL.DbSaveClass
{
   public class CandidateLangDbSave:IMainInterface<CandidateLang>
    {
        CareerPortalEntities dbcontext;
        public CandidateLangDbSave()
        {
            dbcontext = new CareerPortalEntities();

        }

        public CandidateLang AddData(CandidateLang model)
        {
            dbcontext.CandidateLangs.Add(model);
            dbcontext.SaveChanges();

            return model;
        }

        public int AddData(List<CandidateLang> model)
        {
            dbcontext.CandidateLangs.AddRange(model);
            dbcontext.SaveChanges();

            return 1;
        }

        public bool AddDatabool(CandidateLang model)
        {
            dbcontext.CandidateLangs.Add(model);
            dbcontext.SaveChanges();

            return true;
            //throw new NotImplementedException();
        }

        public int Delete(CandidateLang model)
        {
            var Jobpositions = dbcontext.CandidateLangs.Where(m => m.Id == model.Id).FirstOrDefault();
            dbcontext.CandidateLangs.Remove(Jobpositions);
            dbcontext.SaveChanges();
            return 1;
        }

        public int DeleteByUserId(int UserId)
        {
            var Jobpositions = dbcontext.CandidateLangs.Where(m => m.UserId == UserId).ToList();
            dbcontext.CandidateLangs.RemoveRange(Jobpositions);
            dbcontext.SaveChanges();
            return 1;
        }

        public CandidateLang GetByid(int Id)
        {
            var data = dbcontext.CandidateLangs.Where(m => m.Id == Id).FirstOrDefault() ;
            

            return data;
  
        }

        public CandidateLang GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public CandidateLang Getdata(CandidateLang data)
        {
            throw new NotImplementedException();
        }

        public List<CandidateLang> GetList(int Id)
        {
            var data = dbcontext.CandidateLangs.Where(m => m.UserId == Id).ToList();


            return data;
         
        }

        public List<CandidateLang> GetList()
        {
            throw new NotImplementedException();
        }

        public CandidateLang UpdateData(CandidateLang model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataBool(CandidateLang model)
        {
            dbcontext.Entry(model).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();

            return true;
           
        }
    }
}
