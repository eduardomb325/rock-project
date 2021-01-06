using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RockProjectAPI.Controllers
{
    [ApiController]
    [Route("/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
     
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
            ILogger<EmployeeController> logger,
            IEmployeeService employeeService
        )
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetListEmployeesController()
        {
            try
            {
                List<Employee> result = _employeeService.GetEmployeesService();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("save/list")]
        public IActionResult SaveListEmployeesController([FromBody] List<Employee> employeeList)
        {
            try
            {
                List<Employee> result = _employeeService.SaveEmployeesService(employeeList);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
