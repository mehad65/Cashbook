using Cashbook.Api.Entities;
using Cashbook.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cashbook.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParticularController : ControllerBase
    {
        private readonly IParticularRepo _repository;
        private readonly ILogger<ParticularController> _logger;

        public ParticularController(IParticularRepo repository, ILogger<ParticularController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Particular>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Particular>>> GetParticulars()
        {
            var products = await _repository.GetParticulars();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetParticular")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Particular), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Particular>> GetParticularById(string id)
        {
            var particular = await _repository.GetParticular(id);
            if (particular == null)
            {
                _logger.LogError($"Particular with id: {id}, not found.");
                return NotFound();
            }
            return Ok(particular);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Particular), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Particular>> CreateParticular([FromBody] Particular particular)
        {
            await _repository.CreateParticular(particular);

            return CreatedAtRoute("GetParticular", new { id = particular.Particular_Id }, particular);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Particular), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateParticular([FromBody] Particular particular)
        {
            return Ok(await _repository.UpdateParticular(particular));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Particular), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteParticular(id));
        }
    }
}
