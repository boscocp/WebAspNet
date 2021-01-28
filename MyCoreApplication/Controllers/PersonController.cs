using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic; 
using System.Linq; 
using MyCoreApplication.Models;
using System;

namespace MyCoreApplication.Controllers
{
    [Route("api/[controller]")] 
    public class PersonController : ControllerBase     
    {
        private readonly IDataAccessProvider _context; 
        public PersonController(IDataAccessProvider context)
        {
            _context = context;
            //teste
            Models.Person person = new Models.Person();
            person.Name = "Joares";
            person.BirthDate = new DateTime();
            person.CPF = 12345;

            _context.AddPersonRecord(person);
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _context.GetPersonRecords();
        }
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                person.Id = Int64.Parse(obj.ToString());
                _context.AddPersonRecord(person);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Person Details(Int64 id)
        {
            return _context.GetPersonSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.UpdatePersonRecord(person);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(Int64 id)
        {
            var data = _context.GetPersonSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeletePersonRecord(id);
            return Ok();
        }

    }
}