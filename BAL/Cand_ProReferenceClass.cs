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
    public class Cand_ProReferenceClass : Abstracttest<Cand_ProfessionalReferences>
    {
        private DbSaveClass<Cand_ProfessionalReferences> repository = null;
        public Cand_ProReferenceClass()
        {
            this.repository = new DbSaveClass<Cand_ProfessionalReferences>();

        }
        public override List<Cand_ProfessionalReferences> GetList(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m=>m.UserId == Id).ToList();
        }

        public Cand_ProfessionalReferences GetById(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.UserId == Id).FirstOrDefault();
        }
        public override bool AddDatabool(Cand_ProfessionalReferences model)
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
       
        public  bool AddForeach(List<Cand_ProfessionalReferences> modelList)
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
