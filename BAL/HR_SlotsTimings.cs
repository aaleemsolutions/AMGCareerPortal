using BAL.AbstractClasses;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   
    public class HR_SlotsTimings : Abstracttest<TimingSlot>
    {
        private DbSaveClass<TimingSlot> repository = null;
        public HR_SlotsTimings()
        {
            this.repository = new DbSaveClass<TimingSlot>();

        }
        public override List<TimingSlot> GetList(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.Id == Id).ToList();
        }
     
        public TimingSlot GetById(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.Id == Id).FirstOrDefault();
        }
        public override bool AddDatabool(TimingSlot model)
        {
           
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

        public bool AddForeach(List<TimingSlot> modelList)
        {
            //var recordmodel = GetList(GlobalUserInfo.UserId);
            //repository.DeleteRange(recordmodel);
            //repository.Save();
            foreach (var model in modelList)
            {
                //if (model.UserId == null || model.UserId == 0)
                //{
                //    model.UserId = GlobalUserInfo.UserId;

                //}
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
