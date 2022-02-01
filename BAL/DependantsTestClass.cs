using BAL.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BAL.Interfaces;

namespace BAL
{
    public class DependantsTestClass : Abstracttest<Cand_Dependants>
    {
        private DbSaveClass<Cand_Dependants> repository = null;
        public DependantsTestClass()
        {
            this.repository = new DbSaveClass<Cand_Dependants>();

        }
        public override List<Cand_Dependants> GetList(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m=>m.UserId == Id).ToList();
        }
      
        public override bool AddDatabool(Cand_Dependants model)
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
       
        public  bool AddForeach(List<Cand_Dependants> modelList)
        {
            //var recordmodel = GetList(GlobalUserInfo.UserId);
            //repository.DeleteRange(recordmodel);
            //repository.Save();
            foreach (var model in modelList)
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
         
            }
            return true;

        }

        

        //public  bool AddDataRange(List<Cand_Dependants> model)
        //{
        //    if (model.UserId == null || model.UserId == 0)
        //    {
        //        model.UserId = GlobalUserInfo.UserId;

        //    }
        //    if (model.Id != 0)
        //    {
        //        repository.UpdateRecords(model);
        //        repository.Save();
        //    }
        //    else
        //    {
        //        repository.AddRecordsLists(model);
        //        repository.Save();

        //    }
        //    return true;
        //}
    }
}
