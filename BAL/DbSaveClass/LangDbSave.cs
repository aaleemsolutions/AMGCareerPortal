using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;

namespace BAL.DbSaveClass
{
    public class LanguagesClass : IMainInterface<Language>
    {
        CareerPortalEntities1 dbcontext;
        public LanguagesClass()
        {
            dbcontext = new CareerPortalEntities1();
        }

        public Language AddData(Language model)
        {
            throw new NotImplementedException();
        }

        public bool AddDatabool(Language model)
        {
            throw new NotImplementedException();
        }

        public int Delete(Language model)
        {
            throw new NotImplementedException();
        }

        public List<Language> GetList(int Id)
        {
            var dbdata = dbcontext.Languages.Where(m => m.isActive == true).ToList();
            return dbdata;
        }
        public Language GetByid(int Id)
        {
            throw new NotImplementedException();
        }

        public Language GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public Language Getdata(Language data)
        {
            throw new NotImplementedException();
        }

        public Language UpdateData(Language model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataBool(Language model)
        {
            throw new NotImplementedException();
        }

       public List<Language>  GetList()
        {
            var dbdata = dbcontext.Languages.Where(m => m.isActive == true).ToList();
            return dbdata;
        }
    }
    public class LangScoreTypeClass : IMainInterface<LangScoreType>
    {
        CareerPortalEntities1 dbcontext;
        public LangScoreTypeClass()
        {
            dbcontext = new CareerPortalEntities1();
        }

        public LangScoreType AddData(LangScoreType model)
        {
            throw new NotImplementedException();
        }

        public bool AddDatabool(LangScoreType model)
        {
            throw new NotImplementedException();
        }

        public int Delete(LangScoreType model)
        {
            throw new NotImplementedException();
        }

        public LangScoreType GetByid(int Id)
        {
            throw new NotImplementedException();
        }

        public LangScoreType GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public LangScoreType Getdata(LangScoreType data)
        {
            throw new NotImplementedException();
        }

        public List<LangScoreType> GetList(int Id)
        {
            var dbdata = dbcontext.LangScoreTypes.Where(m => m.IsActive == true).ToList();
            return dbdata;
        }

        public LangScoreType UpdateData(LangScoreType model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataBool(LangScoreType model)
        {
            throw new NotImplementedException();
        }

       public List<LangScoreType>  GetList()
        {
            var dbdata = dbcontext.LangScoreTypes.Where(m => m.IsActive == true).ToList();
            return dbdata;
        }
    }
    public class LanguageScoreClass : IMainInterface<LanguageScore>
    {
        CareerPortalEntities1 dbcontext;
        public LanguageScoreClass()
        {
            dbcontext = new CareerPortalEntities1();
        }
        public LanguageScore AddData(LanguageScore model)
        {
            throw new NotImplementedException();
        }

        public bool AddDatabool(LanguageScore model)
        {
            throw new NotImplementedException();
        }

        public int Delete(LanguageScore model)
        {
            throw new NotImplementedException();
        }

        public LanguageScore GetByid(int Id)
        {
            throw new NotImplementedException();
        }

        public LanguageScore GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public LanguageScore Getdata(LanguageScore data)
        {
            throw new NotImplementedException();
        }

        public List<LanguageScore> GetList(int Id)
        {
            var dbdata = dbcontext.LanguageScores.Where(m => m.IsActive == true).ToList();
            return dbdata;
        }

        public LanguageScore UpdateData(LanguageScore model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataBool(LanguageScore model)
        {
            throw new NotImplementedException();
        }

        public List<LanguageScore>  GetList()
        {
            var dbdata = dbcontext.LanguageScores.Where(m => m.IsActive == true).ToList();
            return dbdata;
        }
    }
    public class LanguageMapingClass : IMainInterface<LanguageMaping>
    {
        CareerPortalEntities1 dbcontext;
        public LanguageMapingClass()
        {
            dbcontext = new CareerPortalEntities1();
        }

        public LanguageMaping AddData(LanguageMaping model)
        {
            throw new NotImplementedException();
        }

        public bool AddDatabool(LanguageMaping model)
        {
            throw new NotImplementedException();
        }

        public int Delete(LanguageMaping model)
        {
            throw new NotImplementedException();
        }

        public LanguageMaping GetByid(int Id)
        {
            throw new NotImplementedException();
        }

        public LanguageMaping GetByString(string value)
        {
            throw new NotImplementedException();
        }

        public LanguageMaping Getdata(LanguageMaping data)
        {
            throw new NotImplementedException();
        }

        public List<LanguageMaping> GetList(int Id)
        {
            var dbdata = dbcontext.LanguageMapings.Where(m => m.IsActive == true).ToList();
            return dbdata;
        }

        public LanguageMaping UpdateData(LanguageMaping model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDataBool(LanguageMaping model)
        {
            throw new NotImplementedException();
        }

        public List<LanguageMaping> GetList()
        {
            var dbdata = dbcontext.LanguageMapings.Where(m => m.IsActive == true).ToList();
            return dbdata;
        }
    }
}
