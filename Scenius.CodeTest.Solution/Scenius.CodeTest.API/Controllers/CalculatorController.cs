using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scenius.CodeTest.Data;
using Scenius.CodeTest.Shared;

namespace Scenius.CodeTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private CalculatorDbContext _context;
        private Publisher _publisher;

        public CalculatorController(CalculatorDbContext context, IConfiguration configuration)
        {
            _context = context;
            _publisher = new Publisher(configuration);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetLatestResult()
        //{
            
        //}

        [HttpGet("all")]
        public async Task<IActionResult> GetAllResults()
        {
            return Ok(await _context.CalculationResults.ToListAsync());
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] string rawInput)
        {
            _publisher.Publish(rawInput);
            return Ok();
        }
    }
}
