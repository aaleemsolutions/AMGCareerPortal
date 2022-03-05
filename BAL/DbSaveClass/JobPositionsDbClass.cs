﻿using System;
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
        CareerPortalEntities1 dbcontext;

        public JobPositionsDbClass()
        {
            dbcontext = new CareerPortalEntities1();
        }
        public bool AddPositions(AllPosition Applied)
        {
            
            dbcontext.AllPositions.Add(Applied);
            dbcontext.SaveChanges();
            return true;


            
        }

        public bool DeletePosition(AllPosition Applied)
        {
            dbcontext.AllPositions.Remove(Applied);
            dbcontext.SaveChanges();
            return true;

        }

        public bool DeletePosition(int JobId)
        {
            var Jobpositions = dbcontext.AllPositions.Where(m=>m.JobId == JobId).FirstOrDefault();
            dbcontext.AllPositions.Remove(Jobpositions);
            dbcontext.SaveChanges();
            return true;

        }



        public List<AllPosition> GetAllPositions()
        {
            //var getallpositions  = dbcontext.AllPositions.ToList();

            //return getallpositions;
            var getallpositions = dbcontext.AllPositions.Where(m => m.IsPositionOpen == null || m.IsPositionOpen == true).ToList();

            return getallpositions;

        }

        public List<AllPosition> GetAllPositions(bool OpenPositionsOnly = true)
        {

            var getallpositions = dbcontext.AllPositions.ToList();

            return getallpositions;

        }

        public AllPosition GetPosition(int Applied)
        {
            var getpositions = dbcontext.AllPositions.AsNoTracking().Where(m=>m.JobId== Applied).FirstOrDefault();

            return getpositions;
        }

        public bool UpdatePosition(AllPosition Applied)
        {
            
            dbcontext.Entry(Applied).State = System.Data.Entity.EntityState.Modified;
        
            dbcontext.SaveChanges();

            return true;
        }
    }
}
