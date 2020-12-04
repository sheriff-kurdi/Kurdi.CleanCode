using CleanCode.Core.Contracts;
using CleanCode.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanCode.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeesService.GetAll();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeesService.GetById(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            employeesService.Create(employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            if(employeesService.GetById(id) == null)
            {
                return NotFound();
            }
           return  Ok();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (employeesService.GetById(id) == null)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
