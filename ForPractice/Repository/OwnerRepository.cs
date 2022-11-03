using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForPractice.Repository
{
    class OwnerRepository : IRepository<Owner>
    {
        private BaseForPracticeEntities db;

        public OwnerRepository()
        {
            this.db = new BaseForPracticeEntities();
        }
        public void Create(Owner item)
        {
            db.Owner.Add(item);
        }

        public void Delete(int id)
        {
            var owner = GetById(id);
            if (owner != null)
                db.Owner.Remove(owner);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetAll()
        {
            return db.Owner.ToList();
        }

        public Owner GetById(int id)
        {
            return db.Owner.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Owner item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
