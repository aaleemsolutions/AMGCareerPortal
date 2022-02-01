using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;

namespace BAL.DbSaveClass
{
    public class Cand_RelateFreindWorkingDbSave : IMainInterface<Cand_RelateFreindWorking>
    {
  
        CareerPortalEntities dbcontext;
        public Cand_RelateFreindWorkingDbSave()
        {
            dbcontext = new CareerPortalEntities();
        }
        public Cand_RelateFreindWorking AddData(Cand_RelateFreindWorking model)
        {
            throw new NotImplementedException();
        }

        public bool AddDatabool(Cand_RelateFreindWorking model)
        {
            throw new NotImplementedException();
        }

        public int Delete(Cand_RelateFreindWorking model)
        {
            throw new NotImplementedException();
        }

        public Cand_RelateFreindWorking GetByid(int Id)
        {
            throw new NotImplementedException();
        }

        public Cand_RelateFreindWorking GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public Cand_RelateFreindWorking Getdata(Cand_RelateFreindWorking data)
        {
            throw new NotImplementedException();
        }

        public List<Cand_RelateFreindWorking> GetList(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Cand_RelateFreindWorking> GetList()
        {
            throw new NotImplementedException();
        }

        public Cand_RelateFreindWorking UpdateData(Cand_RelateFreindWorking model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataBool(Cand_RelateFreindWorking model)
        {
            throw new NotImplementedException();
        }
    }
}
