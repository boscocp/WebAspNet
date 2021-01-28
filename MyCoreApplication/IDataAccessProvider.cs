using MyCoreApplication.Models;
using System;
using System.Collections.Generic;  
  
namespace MyCoreApplication  
{  
    public interface IDataAccessProvider  
    {  
        void AddPersonRecord(Person person);  
        void UpdatePersonRecord(Person person);  
        void DeletePersonRecord(Int64 id);  
        Person GetPersonSingleRecord(Int64 id);  
        List<Person> GetPersonRecords();  
    }  
}  