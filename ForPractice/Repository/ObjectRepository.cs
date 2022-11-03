using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForPractice.Repository
{
    class ObjectRepository : IRepository<Object>
    {
        private BaseForPracticeEntities db;

        public ObjectRepository()
        {
            this.db = new BaseForPracticeEntities();
        }
        public void Create(Object item)
        {
            db.Object.Add(item);
        }

        public void Delete(int id)
        {
            var Object = GetById(id);
            if (Object != null)
                db.Object.Remove(Object);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Object> GetAll()
        {
            return db.Object.ToList();
        }

        public Object GetById(int id)
        {
            return db.Object.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Object item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public int GetMaxNumber()
        {
            var allObjects = GetAll();
            var maxNum = allObjects.Select(f => f.ObjectId).Max();
            return maxNum;
        }
    }
}
