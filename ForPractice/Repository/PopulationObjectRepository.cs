using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForPractice.Repository
{
    class PopulationObjectRepository : IRepository<PopulationObject>
    {
        private BaseForPracticeEntities db;

        public PopulationObjectRepository()
        {
            this.db = new BaseForPracticeEntities();
        }
        public void Create(PopulationObject item)
        {
            db.PopulationObject.Add(item);
        }

        public void Delete(int id)
        {
            var PopulationObject = GetById(id);
            if (PopulationObject != null)
                db.PopulationObject.Remove(PopulationObject);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<PopulationObject> GetAll()
        {
            return db.PopulationObject.ToList();
        }

        public PopulationObject GetById(int id)
        {
            return db.PopulationObject.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(PopulationObject item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
