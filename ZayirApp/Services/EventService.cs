using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZayirApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ZayirApp.Services
{
    public class EventService
    {
        // Instance of the db context
        private readonly ZayirDbContext db;

        // Constructor using dependency injection
        public EventService(ZayirDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns>List of all events</returns>
        public List<Event> GetEvents()
        {
            return db.Event.ToList();
        }

        /// <summary>
        /// Get a event
        /// </summary>
        /// <param name="id">Id of the event to return</param>
        /// <returns>A event with the provided id or null</returns>
        public Event GetEvent(int id)
        {
            return db.Event.SingleOrDefault(c => c.EventId == id);
        }

        /// <summary>
        /// Add a new event
        /// </summary>
        /// <param name="event">The vent to add</param>
        /// <returns>True if event is added successfuly otherwise false</returns>
        public bool AddEvent(Event event1)
        {
            if (event1 != null)
            {
                db.Event.Add(event1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a event
        /// </summary>
        /// <param name="id">Id of the event to delete</param>
        /// <returns>True if event is deleted successfuly otherwise false</returns>
        public bool DeleteEvent(int id)
        {
            var event1 = db.Event.Find(id);
            if (event1 != null)
            {
                db.Event.Remove(event1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a event
        /// </summary>
        /// <param name="event">event object</param>
        public void EditEvent(Event event1)
        {
            // Change the state of the event object to modified, so it will be update in database
            db.Entry(event1).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
