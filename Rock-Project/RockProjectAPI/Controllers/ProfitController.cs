using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Services.Interfaces;
using System;

namespace RockProjectAPI.Controllers
{
    [ApiController]
    [Route("/profit")]
    public class ProfitController : ControllerBase
    {
        private readonly IProfitService _profitService;
        public ProfitController(IProfitService profitService)
        {
            _profitService = profitService;
        }

        [HttpPost]
        [Route("get")]
        public IActionResult CalculateProfitController(double expectedProfit)
        {
            try
            {
                Profit response = _profitService.GetProfit(expectedProfit);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
