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
    public class MostRecentEmployementClass : Abstracttest<MoseRecentEmployement>
    {
        private DbSaveClass<MoseRecentEmployement> repository = null;
        public MostRecentEmployementClass()
        {
            this.repository = new DbSaveClass<MoseRecentEmployement>();

        }
        public override List<MoseRecentEmployement> GetList(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m=>m.UserId == Id).ToList();
        }

        public  MoseRecentEmployement GetById(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.UserId == Id).FirstOrDefault();
        }
        public override bool AddDatabool(MoseRecentEmployement model)
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
       
        public  bool AddForeach(List<MoseRecentEmployement> modelList)
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

        

    }
}
