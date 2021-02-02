using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dockerCompose.Models;

namespace personregister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/Person
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            List<Person> persons = new List<Person>();
            PSQLConection.DataAccess.IDataAccessProvider dbPerson = new PSQLConection.DataAccess.DataAccessProvider();
            Console.WriteLine("Aqui");
            persons = dbPerson.GetPersonRecords();
            foreach (Person person in persons)
            {
                Console.WriteLine(person.Name + person.Id + " income " + person.Income + " birth " + person.BirthDate);
            }
            return persons;
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public Person Get(int id)
        {
            PSQLConection.DataAccess.IDataAccessProvider dbPerson = new PSQLConection.DataAccess.DataAccessProvider();
            Person person = dbPerson.GetPersonSingleRecord(id);
            return person;
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] Person personJSON)
        {
            PSQLConection.DataAccess.IDataAccessProvider dbPerson = new PSQLConection.DataAccess.DataAccessProvider();
            dbPerson.AddPersonRecord(personJSON);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person personJSON)
        {
            PSQLConection.DataAccess.IDataAccessProvider dbPerson = new PSQLConection.DataAccess.DataAccessProvider();
            Person person = dbPerson.GetPersonSingleRecord(id);
            dbPerson.UpdatePersonRecord(person, personJSON);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PSQLConection.DataAccess.IDataAccessProvider dbPerson = new PSQLConection.DataAccess.DataAccessProvider();
            Person person = dbPerson.GetPersonSingleRecord(id);
            dbPerson.DeletePersonRecord(person);
        }
    }
}
