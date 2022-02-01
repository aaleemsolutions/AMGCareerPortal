using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    interface GenericDbSAVE<T> where T : class 

    {
        T GetRecordsById(int Id);
        List<T> GetAllRecord();
        T AddRecords(T AddRecordModel);
        int UpdateRecords(T UpdateModel);

        int DeleteRecords(T Id);

        void UpdateRecordsLists(List<T> UpdateModel);
        void AddRecordsLists(List<T> UpdateModel);
        void Save();
    }
}
