
using CleanCode.Core.Entities;
using CleanCode.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanCode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {


        private readonly IEmployeeService employeesService;

        public EmployeesController(IEmployeeService employeesService)
        {
            this.employeesService = employeesService;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IQueryable<Employee> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return employeesService.FindAll(pageSize, pageNumber);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id, [FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            return employeesService.FindByCondition(e => e.Id == id, pageSize, pageNumber).FirstOrDefault();
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            employeesService.Create(employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee, [FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            if (employeesService.FindByCondition(e => e.Id == id, pageSize, pageNumber).FirstOrDefault() == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (employeesService.FindByCondition(e => e.Id == id).FirstOrDefault() == null)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
