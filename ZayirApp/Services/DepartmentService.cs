using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZayirApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ZayirApp.Services
{
        public class DepartmentService
        {
            // Instance of the db context
            private readonly ZayirDbContext db;

            // Constructor using dependency injection
            public DepartmentService(ZayirDbContext context)
            {
                db = context;
            }

        /// <summary>
        /// Get all Departments
        /// </summary>
        /// <returns>List of all Departments</returns>
        public List<Department> GetDepartments()
            {
                return db.Department.ToList();
            }

        /// <summary>
        /// Get a Department
        /// </summary>
        /// <param name="id">Id of the Department to return</param>
        /// <returns>A Department with the provided id or null</returns>
        public Department GetDepartment(int id)
            {
                return db.Department.SingleOrDefault(d => d.DepartmentId == id);
            }

        /// <summary>
        /// Add a new Department
        /// </summary>
        /// <param name="Department">The Department to add</param>
        /// <returns>True if Department is added successfuly otherwise false</returns>
        public bool AddDepartment(Department department)
            {
                if (department != null)
                {
                    db.Department.Add(department);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }

        /// <summary>
        /// Delete a department
        /// </summary>
        /// <param name="id">Id of the department to delete</param>
        /// <returns>True if department is deleted successfuly otherwise false</returns>
        public bool DeleteDepartment(int id)
            {
                var department = db.Department.Find(id);
                if (department != null)
                {
                    db.Department.Remove(department);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }

        /// <summary>
        /// Update a department
        /// </summary>
        /// <param name="department">department object</param>
        public void EditDepartment(Department department)
            {
            // Change the state of the department object to modified, so it will be update in database
            db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
}