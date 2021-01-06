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
    [Route("/weight/work-years")]
    public class WorkYearsWeightController : ControllerBase
    {
        private readonly IWeightService<WorkYearsWeight> _weightService;
        private readonly ILogger<WorkYearsWeightController> _logger;

        public WorkYearsWeightController(ILogger<WorkYearsWeightController> logger, IWeightService<WorkYearsWeight> weightService)
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
                List<WorkYearsWeight> result = _weightService.GetWeightList();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
