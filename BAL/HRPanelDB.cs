using BAL.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using DAL;

namespace BAL
{
    public class HRPanelDB : Abstracttest<InterviewPanel>

    {
        private DbSaveClass<InterviewPanel> repository = null;
        public HRPanelDB()
        {
            this.repository = new DbSaveClass<InterviewPanel>();
        }
    }

    public class InterviewPanelDetail : Abstracttest<DAL.InterviewPanelDetail>

    {
        private DbSaveClass<DAL.InterviewPanelDetail> repository = null;
        public InterviewPanelDetail()
        {
            this.repository = new DbSaveClass<DAL.InterviewPanelDetail>();
        }

        public   List<DAL.InterviewPanelDetail> GetListByPanelId(int Id)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.PanelId == Id).ToList();
        }
    }


    public class HRPanelEmployee : Abstracttest<InterviewPerson>
    {
        private DbSaveClass<InterviewPerson> repository = null;
        public HRPanelEmployee()
        {

            this.repository = new DbSaveClass<InterviewPerson>();

        }
    }

   

}
