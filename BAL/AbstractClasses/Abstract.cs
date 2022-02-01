using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.AbstractClasses
{
   public abstract class Abstracttest<T> : IMainInterface<T> where T : class
    {   private DbSaveClass<T> repository = null;
        public Abstracttest()
        {
            this.repository = new DbSaveClass<T>();

        }
        public T AddData(T model)
        {
            repository.AddRecords(model);
            repository.Save();
            return model;
        }
        public void AddRange(List<T> model)
        {

            repository.AddRecordsLists(model);
            repository.Save();
           
        }

        public virtual bool AddDatabool(T model)
        {
            AddData(model);
            return true;
        }

        public int Delete(T model)
        {

            repository.DeleteRecords(model);
            return 1;
        }
        public void DeleteById(int Id)
        {
            repository.DeleteRecords(Id);
            repository.Save();
            
        }

        public T GetByid(int Id)
        {
            return repository.GetRecordsById(Id);
        }

        public T GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public T Getdata(T data)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetList(int Id)
        {
            return repository.GetAllRecord();
        }

        public List<T> GetList()
        {

            return repository.GetAllRecord();
        }

        public T UpdateData(T model)
        {
            repository.UpdateRecords(model);
            repository.Save();

            return model;
        }

        public bool UpdateDataBool(T model)
        {
            
            UpdateData(model);
            return true;
        }
    }
}
