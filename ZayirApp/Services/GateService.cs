using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZayirApp.Data;

namespace ZayirApp.Services
{
    public class GateService
    {
        // Instance of the db context
        private readonly ZayirDbContext db;

        // Constructor using dependency injection
        public GateService(ZayirDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Gates
        /// </summary>
        /// <returns>List of all categories</returns>
        public List<Gate> GetGates()
        {
            return db.Gate.ToList();
        }

        /// <summary>
        /// Get a Gate
        /// </summary>
        /// <param name="id">Id of the gate to return</param>
        /// <returns>A gate with the provided id or null</returns>
        public Gate GetGate(int id)
        {
            return db.Gate.SingleOrDefault(c => c.GateId == id);
        }

        /// <summary>
        /// Add a new gate
        /// </summary>
        /// <param name="gate">The gate to add</param>
        /// <returns>True if gate is added successfuly otherwise false</returns>
        public bool AddGate(Gate gate)
        {
            if (gate != null)
            {
                db.Gate.Add(gate);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a gate
        /// </summary>
        /// <param name="id">Id of the gate to delete</param>
        /// <returns>True if gate is deleted successfuly otherwise false</returns>
        public bool DeleteGate(int id)
        {
            var gate = db.Gate.Find(id);
            if (gate != null)
            {
                db.Gate.Remove(gate);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a gate
        /// </summary>
        /// <param name="gate">gate object</param>
        public void EditGate(Gate gate)
        {
            // Change the state of the gate object to modified, so it will be edit in database
            db.Entry(gate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

