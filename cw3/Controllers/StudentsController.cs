using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using cw3.Models;
using cw3.Services;

namespace cw3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService service)
        {
            _dbService = service;
        }

        //2. QueryString
        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        //[FromRoute], [FromBody], [FromQuery]
        //1. URL segment
        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute]int id) //action method
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }

            else if (id == 2)
            {
                return Ok("Majewski");
            }
            return NotFound("Nie znaleziono studenta");
        }

        //3. Body - cialo zadan
        [HttpPost]
        public IActionResult CreateStudent([FromBody]Student student)
        {
            student.IndexNumber=$"s{new Random().Next(1, 20000)}";
            //...
            return Ok(student); //JSON
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)

        {
            return Ok("Usuwanie ukonczone");
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Aktualizacja dokonczona");
        }


    }
}