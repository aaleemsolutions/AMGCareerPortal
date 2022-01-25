using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.DbSaveClass;
using ViewModels;
using BAL;


namespace BAL
{
    public class LanguagesModel:IMainInterface<JobApplicationViewModel>
    {
        LanguagesClass LanguagesClass;
        LanguageScoreClass LanguageScoreClass;
        LangScoreTypeClass LangScoreTypeClass;
        LanguageMapingClass LanguageMapingClass;
        CandidateLangDbSave candidateLangDbSave;


        public LanguagesModel()
        {
            LanguagesClass = new LanguagesClass();
            LanguageScoreClass = new LanguageScoreClass();
            LangScoreTypeClass = new LangScoreTypeClass();
            LanguageMapingClass = new LanguageMapingClass();
            candidateLangDbSave = new CandidateLangDbSave();
        }

       
        public JobApplicationViewModel AddData(JobApplicationViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool AddDatabool(JobApplicationViewModel model)
        {
            throw new NotImplementedException();
        }

        public int Delete(JobApplicationViewModel model)
        {
            throw new NotImplementedException();
        }

        public JobApplicationViewModel GetByid(int Id)
        {
            throw new NotImplementedException();
        }

        public JobApplicationViewModel GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public JobApplicationViewModel Getdata(JobApplicationViewModel data)
        {
            throw new NotImplementedException();
        }
        public JobApplicationViewModel Getdata()
        {
            var model = new JobApplicationViewModel();
            model.LanguageMapings = LanguageMapingClass.GetList();
            model.candLang = candidateLangDbSave.GetList(GlobalUserInfo.UserId);

            return model;

        }

        public List<JobApplicationViewModel> GetList(int Id)
        {
            throw new NotImplementedException();
        }

        public List<JobApplicationViewModel> GetList()
        {
            throw new NotImplementedException();
        }

        public JobApplicationViewModel UpdateData(JobApplicationViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataBool(JobApplicationViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
