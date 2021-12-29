using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;

namespace BAL.CandidateDbSaveClass
{
    public class JobPositionsDbClass : IJobPositions<AllPosition>
    {
        CareerPortalEntities dbcontext;

        public JobPositionsDbClass()
        {
            dbcontext = new CareerPortalEntities();
        }
        public bool AddPositions(AllPosition JPosition)
        {
            
            dbcontext.AllPositions.Add(JPosition);
            dbcontext.SaveChanges();
            return true;


            
        }

        public bool DeletePosition(AllPosition JPosition)
        {
            dbcontext.AllPositions.Remove(JPosition);
            dbcontext.SaveChanges();
            return true;

        }

        public List<AllPosition> GetAllPositions()
        {
            var getallpositions  = dbcontext.AllPositions.ToList();
            
            return getallpositions;

        }

        public AllPosition GetPosition(int PositionId)
        {
            var getpositions = dbcontext.AllPositions.Where(m=>m.JobId==PositionId).FirstOrDefault();

            return getpositions;
        }

        public bool UpdatePosition(AllPosition JPosition)
        {
            dbcontext.Entry(JPosition).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();

            return true;
        }
    }
}
