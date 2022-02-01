using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;

namespace BAL.DbSaveClass
{
    public class MostRecentDbSave : IMainInterface<MoseRecentEmployement>
    {
        CareerPortalEntities dbcontext;
        public MostRecentDbSave()
        {
            dbcontext = new CareerPortalEntities();

        }
        public MoseRecentEmployement AddData(MoseRecentEmployement model)
        {
            throw new NotImplementedException();
        }

        public bool AddDatabool(MoseRecentEmployement model)
        {
            throw new NotImplementedException();
        }

        public int Delete(MoseRecentEmployement model)
        {
            throw new NotImplementedException();
        }

        public MoseRecentEmployement GetByid(int Id)
        {
            throw new NotImplementedException();
        }

        public MoseRecentEmployement GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public MoseRecentEmployement Getdata(MoseRecentEmployement data)
        {
            throw new NotImplementedException();
        }

        public List<MoseRecentEmployement> GetList(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MoseRecentEmployement> GetList()
        {
            throw new NotImplementedException();
        }

        public MoseRecentEmployement UpdateData(MoseRecentEmployement model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataBool(MoseRecentEmployement model)
        {
            throw new NotImplementedException();
        }
    }
}
