using BAL.AbstractClasses;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class IntEvaluation
    {
        public IntEvaluation()
        {

        }
    }

    public class IntEvQuestions : Abstracttest<DAL.IntEvQuestion>
    {
        private DbSaveClass<IntEvQuestion> repository = null;
        public IntEvQuestions()
        {
            this.repository = new DbSaveClass<IntEvQuestion>();

        }
    }

    public class IntEvQuestionsMapping : Abstracttest<DAL.IntQuestionMapping>
    {
        private DbSaveClass<IntQuestionMapping> repository = null;
        public IntEvQuestionsMapping()
        {
            this.repository = new DbSaveClass<IntQuestionMapping>();

        }
    }
    public class DecisionList : Abstracttest<DAL.IntEvDecision>
    {
        private DbSaveClass<IntEvDecision> repository = null;
        public DecisionList()
        {
            this.repository = new DbSaveClass<IntEvDecision>();

        }
    }
    public class CndEvaluationMaster: Abstracttest<DAL.cndEvMaster>
    {
        private DbSaveClass<cndEvMaster> repository = null;
        public CndEvaluationMaster()
        {
            this.repository = new DbSaveClass<cndEvMaster>();

        }

        public  cndEvMaster GetById(int ShortListId)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.ShortListId == ShortListId).FirstOrDefault();
        }
    }

    public class CndEvaluationDetail : Abstracttest<DAL.cndEvDetail>
    {
        private DbSaveClass<cndEvDetail> repository = null;
        public CndEvaluationDetail()
        {
            this.repository = new DbSaveClass<cndEvDetail>();

        }

        public override List<cndEvDetail> GetList(int MasterId)
        {
            var modeldata = repository.GetAllRecord();
            return modeldata.Where(m => m.cndEvMasterId == MasterId).ToList();
        }
    }
}