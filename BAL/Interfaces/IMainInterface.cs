using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IMainInterface<T>
    {
        T Getdata(T data);
        T GetByString(string value);
        T GetByid(int Id);
        List<T> GetList(int Id);
        List<T> GetList();

        T AddData(T model);
        T UpdateData(T model);
        int Delete(T model);
        bool UpdateDataBool(T model);
        bool AddDatabool(T model);



    }
}
