using MyCoreApplication.Models;
using System;
using System.Collections.Generic;  
using System.Linq;  
  
namespace MyCoreApplication  
{  
    public class DataAccessProvider: IDataAccessProvider  
    {  
        private readonly PersonContext _context;  
  
        public DataAccessProvider(PersonContext context)  
        {  
            _context = context;  
        }  
  
        public void AddPersonRecord(Person person)  
        {  
            _context.Person.Add(person);  
            _context.SaveChanges();  
        }  
  
        public void UpdatePersonRecord(Person person)  
        {  
            _context.Person.Update(person);  
            _context.SaveChanges();  
        }  
  
        public void DeletePersonRecord(Int64 id)  
        {  
            var entity = _context.Person.FirstOrDefault(t => t.Id == id);  
            _context.Person.Remove(entity);  
            _context.SaveChanges();  
        }  
  
        public Person GetPersonSingleRecord(Int64 id)  
        {  
            return _context.Person.FirstOrDefault(t => t.Id == id);  
        }  
  
        public List<Person> GetPersonRecords()  
        {  
            return _context.Person.ToList();  
        }
    }  
}  