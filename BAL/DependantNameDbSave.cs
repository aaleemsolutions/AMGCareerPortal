using BAL.AbstractClasses;
using BAL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class DependantNameDbSave : IMainInterface<Cand_Dependants>
    {
        private GenericDbSAVE<Cand_Dependants> repository = null;
        public DependantNameDbSave()
        {
            this.repository = new DbSaveClass<Cand_Dependants>();

        }
        public Cand_Dependants AddData(Cand_Dependants model)
        {
            repository.AddRecords(model);
            repository.Save();
            return model;
            
        }

        public bool AddDatabool(Cand_Dependants model)
        {
            AddData(model);
            return true;
        }

        public int Delete(Cand_Dependants model)
        {
            throw new NotImplementedException();

         
        }

        public Cand_Dependants GetByid(int Id)
        {

            return repository.GetRecordsById(Id);
        }

        public Cand_Dependants GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public Cand_Dependants Getdata(Cand_Dependants data)
        {
            throw new NotImplementedException();
        }

        public List<Cand_Dependants> GetList(int Id)
        {
            return repository.GetAllRecord();
        }

        public List<Cand_Dependants> GetList()
        {
            return repository.GetAllRecord();
        }

        public Cand_Dependants UpdateData(Cand_Dependants model)
        {
            repository.UpdateRecords(model);
            repository.Save();

            return model;
        }

        public bool UpdateDataBool(Cand_Dependants model)
        {
            UpdateData(model);
            return true;
        }
    }
}
