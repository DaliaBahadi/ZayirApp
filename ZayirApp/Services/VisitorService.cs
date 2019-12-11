using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZayirApp.Data;

namespace ZayirApp.Services
{
    public class VisitorService
    {
        // Instance of the db context
        private readonly ZayirDbContext db;

        // Constructor using dependency injection
        public VisitorService(ZayirDbContext context)
        {
            db = context;
        }

        public List<Visitor> GetVisitors()
        {
            return db.Visitor.ToList();
        }

        public Visitor GetVisitor(int id)
        {
            return db.Visitor.SingleOrDefault(c => c.VisitorId == id);
        }

        public bool AddNewVisitor(Visitor visitor)
        {
            if (visitor != null)
            {
                db.Visitor.Add(visitor);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteVisitor(int id)
        {
            var visitor = db.Visitor.Find(id);
            if (visitor != null)
            {
                db.Visitor.Remove(visitor);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditVisitor(Visitor visitor)
        {
            db.Entry(visitor).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}