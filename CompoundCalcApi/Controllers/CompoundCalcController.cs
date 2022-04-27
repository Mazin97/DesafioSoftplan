using CompoundCalcApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompoundCalcApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompoundCalcController : ControllerBase
    {
        private readonly ILogger<CompoundCalcController> _logger;
        private readonly IFeeService _feeService;

        public CompoundCalcController(ILogger<CompoundCalcController> logger, IFeeService feeService)
        {
            _logger = logger;
            _feeService = feeService;
        }

        [Route("/CalculaJuros")]
        [HttpGet]
        public async Task<IActionResult> Get(double initialValue, int monthsQuantity)
        {
            try
            {
                return Ok(await _feeService.CalcCompoundInterestAsync(initialValue, monthsQuantity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}