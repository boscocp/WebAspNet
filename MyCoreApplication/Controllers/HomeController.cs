using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCoreApplication.Models;

namespace MyCoreApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataAccessProvider _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
            //teste
            Models.Person person = new Models.Person();
            person.Name = "Joares";
            person.BirthDate = new DateTime();
            person.CPF = 12345;

            _context.AddPersonRecord(person);
        }

        // [HttpGet]
        // public IEnumerable<Person> Get()
        // {
        //     return _context.GetPersonRecords();
        // }
        // [HttpPost]
        // public IActionResult Create([FromBody] Person person)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         Guid obj = Guid.NewGuid();
        //         person.Id = Int64.Parse(obj.ToString());
        //         _context.AddPersonRecord(person);
        //         return Ok();
        //     }
        //     return BadRequest();
        // }

        // [HttpGet("{id}")]
        // public Person Details(Int64 id)
        // {
        //     return _context.GetPersonSingleRecord(id);
        // }

        // [HttpPut]
        // public IActionResult Edit([FromBody] Person person)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.UpdatePersonRecord(person);
        //         return Ok();
        //     }
        //     return BadRequest();
        // }

        // [HttpDelete("{id}")]
        // public IActionResult DeleteConfirmed(Int64 id)
        // {
        //     var data = _context.GetPersonSingleRecord(id);
        //     if (data == null)
        //     {
        //         return NotFound();
        //     }
        //     _context.DeletePersonRecord(id);
        //     return Ok();
        // }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
