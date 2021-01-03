using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RockProjectAPI.Controllers
{
    [ApiController]
    [Route("/weight/occupation-area")]
    public class OccupationAreaWeightController : Controller
    {
        private readonly IWeightService<OccupationAreaWeight> _weightService;
        private readonly ILogger<OccupationAreaWeightController> _logger;

        public OccupationAreaWeightController(ILogger<OccupationAreaWeightController> logger, IWeightService<OccupationAreaWeight> weightService)
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
                List<OccupationAreaWeight> result = _weightService.GetWeightList();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("save/list")]
        public IActionResult SaveListOccupationAreaWeightController(List<OccupationAreaWeight> occupationAreaWeightList)
        {
            try
            {
                List<OccupationAreaWeight> result = _weightService.SaveWeightList(occupationAreaWeightList);

                return Ok(result);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
