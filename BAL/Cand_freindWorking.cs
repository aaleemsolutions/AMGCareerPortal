using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BAL.Interfaces;
using BAL.AbstractClasses;

namespace BAL
{
    public class Cand_freindWorking : IMainInterface<Cand_RelateFreindWorking>
    {
        private GenericDbSAVE<Cand_RelateFreindWorking> repository = null;
        public Cand_freindWorking()
        {
            this.repository = new DbSaveClass<Cand_RelateFreindWorking>();
        }
        public Cand_RelateFreindWorking AddData(Cand_RelateFreindWorking model)
        {
            repository.AddRecords(model);
            repository.Save();

            return model;
        }

        public bool AddDatabool(Cand_RelateFreindWorking model)
        {
            repository.AddRecords(model);
            repository.Save();

            return true;
        }

        public int Delete(Cand_RelateFreindWorking model)
        {

            repository.DeleteRecords(model);
            repository.Save();

            return 1;
        }

        public Cand_RelateFreindWorking GetByid(int Id)
        {
            return repository.GetRecordsById(Id);

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
            var list = repository.GetAllRecord();
            return list.Where(m => m.UserId == Id).ToList();
        }

        public List<Cand_RelateFreindWorking> GetList()
        {
            return repository.GetAllRecord();
        }

        public Cand_RelateFreindWorking UpdateData(Cand_RelateFreindWorking model)
        {
            repository.UpdateRecords(model);
            repository.Save();
            return model;
        }

        public bool UpdateDataBool(Cand_RelateFreindWorking model)
        {
            repository.UpdateRecords(model);
            repository.Save();
            return true;
        }

        public void UpdateListReocord(List<Cand_RelateFreindWorking> model)
        {
            foreach (var item in model)
            {
                if (item.Id != 0)
                {
                    repository.UpdateRecords(item);
                    repository.Save();
                }
                else
                {
                    repository.AddRecords(item);
                    repository.Save();

                }

            }

        }
        public void AddListReocord(List<Cand_RelateFreindWorking> model)
        {
            foreach (var item in model)
            {
                if (item.UserId == null || item.UserId == 0)
                {
                    item.UserId = GlobalUserInfo.UserId;

                }
                if (item.Id != 0)
                {
                    repository.UpdateRecords(item);
                    repository.Save();
                }
                else
                {
                    repository.AddRecords(item);
                    repository.Save();

                }

            }




        }
    }

    public class PreivousWorkAtAM : IMainInterface<Cand_AMPreviousWork>
    {
        private GenericDbSAVE<Cand_AMPreviousWork> repository = null;
        public PreivousWorkAtAM()
        {
            this.repository = new DbSaveClass<Cand_AMPreviousWork>();
        }

        public Cand_AMPreviousWork AddData(Cand_AMPreviousWork model)
        {
            if (model.UserId == null || model.UserId == 0)
            {
                model.UserId = GlobalUserInfo.UserId;

            }
            if (model.Id != 0)
            {
                repository.UpdateRecords(model);
                repository.Save();
            }
            else
            {
                repository.AddRecords(model);
                repository.Save();

            }
            return model;
        }

        public bool AddDatabool(Cand_AMPreviousWork model)
        {
            if (model.UserId == null || model.UserId == 0)
            {
                model.UserId = GlobalUserInfo.UserId;

            }
            if (model.Id != 0)
            {
                repository.UpdateRecords(model);
                repository.Save();
            }
            else
            {
                repository.AddRecords(model);
                repository.Save();

            }
            return true;
        }

        public int Delete(Cand_AMPreviousWork model)
        {
            repository.DeleteRecords(model);
            repository.Save();
            return 1;
        }

        public Cand_AMPreviousWork GetByid(int Id)
        {
            var modeldata = repository.GetAllRecord();
            

            return modeldata.Where(m=>m.UserId == Id).FirstOrDefault();
        }

        public Cand_AMPreviousWork GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public Cand_AMPreviousWork Getdata(Cand_AMPreviousWork data)
        {
            throw new NotImplementedException();
        }

        public List<Cand_AMPreviousWork> GetList(int Id)
        {

            return repository.GetAllRecord();
            
        }

        public List<Cand_AMPreviousWork> GetList()
        {

            return repository.GetAllRecord();
      
        }

        public Cand_AMPreviousWork UpdateData(Cand_AMPreviousWork model)
        {

            if (model.UserId == null || model.UserId == 0)
            {
                model.UserId = GlobalUserInfo.UserId;

            }
            if (model.Id != 0)
            {
                repository.UpdateRecords(model);
                repository.Save();
            }
            else
            {
                repository.AddRecords(model);
                repository.Save();

            }
            return model;
        }

        public bool UpdateDataBool(Cand_AMPreviousWork model)
        {

            if (model.UserId == null || model.UserId == 0)
            {
                model.UserId = GlobalUserInfo.UserId;

            }
            if (model.Id != 0)
            {
                repository.UpdateRecords(model);
                repository.Save();
            }
            else
            {
                repository.AddRecords(model);
                repository.Save();

            }
 
            return true;
        }
    }
}
