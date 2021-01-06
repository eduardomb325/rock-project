using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Controllers
{
    [ApiController]
    [Route("/weight/salary")]
    public class SalaryWeightController : ControllerBase
    {
        private readonly IWeightService<SalaryWeight> _weightService;
        private readonly ILogger<SalaryWeightController> _logger;

        public SalaryWeightController(ILogger<SalaryWeightController> logger, IWeightService<SalaryWeight> weightService)
        {
            _weightService = weightService;
            _logger = logger;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetListOccupationAreaWeightController()
        {
            try
            {
                List<SalaryWeight> result = _weightService.GetWeightList();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
