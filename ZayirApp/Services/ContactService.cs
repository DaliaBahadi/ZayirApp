using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZayirApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ZayirApp.Services
{
    public class ContactService
    {

        
            // Instance of the db context
            private readonly ZayirDbContext db;

            // Constructor using dependency injection
            public ContactService(ZayirDbContext context)
            {
                db = context;
            }

            public List<Contact> GetContacts()
            {
                return db.Contact.ToList();
            }

            public Contact GetContact(int id)
            {
                return db.Contact.SingleOrDefault(c => c.ContactId == id);
            }

            public bool AddNewContact(Contact contact)
            {
                if (contact != null)
                {
                    db.Contact.Add(contact);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }

            public bool DeleteContact(int id)
            {
                var contact = db.Contact.Find(id);
                if (contact != null)
                {
                    db.Contact.Remove(contact);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }

            public void EditContact(Contact contact)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }



