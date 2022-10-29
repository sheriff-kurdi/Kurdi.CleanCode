
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Kurdi.CleanCode.Core.Entities;
using Kurdi.CleanCode.Infrastructure.DTOs;
using Kurdi.CleanCode.Services.Contracts;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kurdi.CleanCode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {


        private readonly IEmployeeService _employeesService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeesService, IMapper mapper)
        {
            this._employeesService = employeesService;
            this._mapper = mapper;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public List<EmployeeDto> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var employeesDto = new List<EmployeeDto>();
            foreach (var emp in _employeesService.FindAll(pageSize, pageNumber))
            {
                employeesDto.Add(_mapper.Map<EmployeeDto>(emp));
            
            }
            //TODO why not working
            //IQueryable < EmployeeDTO > employeesDto = mapper.Map<IQueryable<EmployeeDTO>>(employeesService.FindAll(pageSize, pageNumber));
            return employeesDto;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id:int}")]
        public Employee? Get(int id, [FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            
            return _employeesService.FindByCondition(e => e.Id == id, pageSize, pageNumber).FirstOrDefault();
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _employeesService.Create(employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee, [FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            if (_employeesService.FindByCondition(e => e.Id == id, pageSize, pageNumber).FirstOrDefault() == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_employeesService.FindByCondition(e => e.Id == id).FirstOrDefault() == null)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
