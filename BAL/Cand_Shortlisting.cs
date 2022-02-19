using BAL.AbstractClasses;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
  

    public class Cand_Shortlisting : Abstracttest<HrShortlisting>
    {
        private DbSaveClass<HrShortlisting> repository = null;
        public Cand_Shortlisting()
        {
            this.repository = new DbSaveClass<HrShortlisting>();

        }
        public override List<HrShortlisting> GetList(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.CandApplyId == Id).ToList();
        }

        public List<HrShortlisting> GetList(int JobId,int candidateAppliedId)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.CandApplyId == candidateAppliedId && m.JobId  == JobId).ToList();
        }

        public HrShortlisting GetById(int JobApplyId)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.CandApplyId== JobApplyId).FirstOrDefault();
        }
        public override bool AddDatabool(HrShortlisting model)
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
            return true;
        }

        public bool AddForeach(List<HrShortlisting> modelList)
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
