using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    interface GenericDbSAVE<T>

    {
        T GetRecordsById(int CndExpId);
        List<T> GetAllRecord();
        T AddRecords(T candExpId);
        int UpdateRecords(T candExpId);

        int DeleteRecords(T CndExpId);

    }
}
