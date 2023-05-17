using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TransactionAPI.Models;
using TransactionAPI.Service;

namespace TransactionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProducerController : Controller
    {
        private readonly ProducerService _producer;
        private readonly ILogger _logger; //implementing log4net....

        public ProducerController(ProducerService producer, ILogger<ProducerController> logger)
        {
            _producer = producer;
            _logger = logger;
        }

        [HttpPost("sendTransactions")]
        [SwaggerResponse(StatusCodes.Status200OK, "Submit Transaction Message successfully")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized, Request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Oops! Can't get your Post right now")]
        public async Task<IActionResult> Post([FromBody] TransactionDetails transaction)
        {
            _logger.LogInformation("-----Program started-----");
            int result = await _producer.SentMessages(transaction);
            if (result > 0)
            {
                _logger.LogInformation("Submit Transaction Message successfully");
                return Ok(true);
            }
            else
            {
                _logger.LogError("Bad Request");
                return BadRequest("Bad Request");
                
            }

        }
    }
}
