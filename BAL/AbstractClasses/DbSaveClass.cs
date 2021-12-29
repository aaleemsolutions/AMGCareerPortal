using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;

namespace BAL.AbstractClasses
{
    abstract class DbSaveClass<T> : GenericDbSAVE<T>

    {
        CareerPortalEntities dbcontext;
        public DbSaveClass()
        {
            dbcontext = new CareerPortalEntities();
        }
        public T AddRecords(T candExpId)
        {  
            throw new NotImplementedException();
        }

        public int DeleteRecords(T CndExpId)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllRecord()
        {
            throw new NotImplementedException();
        }

        public T GetRecordsById(int CndExpId)
        {
            throw new NotImplementedException();
        }

        public int UpdateRecords(T candExpId)
        {
            throw new NotImplementedException();
        }
    }
}
