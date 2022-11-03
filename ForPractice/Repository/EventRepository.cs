using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForPractice.Repository
{
    class EventRepository : IRepository<Event>
    {
        private BaseForPracticeEntities db;

        public EventRepository()
        {
            this.db = new BaseForPracticeEntities();
        }
        public void Create(Event item)
        {
            db.Event.Add(item);
        }

        public void Delete(int id)
        {
            var eventt = GetById(id);
            if (eventt != null)
                db.Event.Remove(eventt);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAll()
        {
            return db.Event.ToList();
        }

        public Event GetById(int id)
        {
            return db.Event.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Event item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
