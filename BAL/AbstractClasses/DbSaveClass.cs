using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;

namespace BAL.AbstractClasses
{
    public class DbSaveClass<T> : GenericDbSAVE<T> where T : class

    {
        private CareerPortalEntities1 _context;
        private DbSet<T> table = null;
        public DbSaveClass()
        {
            this._context = new CareerPortalEntities1();
            table = _context.Set<T>();
            //dbcontext = new CareerPortalEntities1();
        }

        public T AddRecords(T AddRecordModel)
        {
            return table.Add(AddRecordModel);
            
        }

        public int DeleteRecords(object Id)
        {
            T Existing = table.Find(Id);
            if (Existing!=null)
            {
                table.Remove(Existing);
            }
           
            return 1;
            
        }
        public void DeleteRecords(T model)
        {
       
            table.Remove(model);
         

        }
        public void DeleteRange(List<T> model)
        {

            table.RemoveRange(model);


        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllRecord()
        {
            return table.ToList();
        }

        public T GetRecordsById(int Id)
        {
            return table.Find(Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public int UpdateRecords(T UpdateModel)
        {
            //dbcontext.Entry(model).State = System.Data.Entity.EntityState.Modified;
            //table.Attach(UpdateModel);
            //_context.Entry(UpdateModel).State = EntityState.Modified;
            _context.Entry(UpdateModel).State = System.Data.Entity.EntityState.Modified;
            return 1;
        }

        public void UpdateRecordsLists(List<T> UpdateModel)
        {
            table.AddRange(UpdateModel);
            _context.Entry(UpdateModel).State = EntityState.Modified;
            
        }
        public void AddRecordsLists(List<T> UpdateModel)
        {
            table.AddRange(UpdateModel);
            

        }
        int GenericDbSAVE<T>.DeleteRecords(T Id)
        {
            throw new NotImplementedException();
        }
    }
}
