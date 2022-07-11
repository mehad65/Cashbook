using Cashbook.Api.Entities;
using Cashbook.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Cashbook.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepo _repository;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionRepo repository, ILogger<TransactionController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Transaction>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetProducts()
        {
            var products = await _repository.GetTransactions();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetTransaction")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Transaction), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Transaction>> GetTransactionById(string id)
        {
            var transaction = await _repository.GetTransaction(id);
            if (transaction == null)
            {
                _logger.LogError($"Transaction with id: {id}, not found.");
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Transaction), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Transaction>> CreateParticular([FromBody] Transaction transaction)
        {
            await _repository.CreateTransaction(transaction);

            return CreatedAtRoute("GetTransaction", new { id = transaction.Tran_Id }, transaction);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Transaction), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTransaction([FromBody] Transaction transaction)
        {
            return Ok(await _repository.UpdateTransaction(transaction));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteTransaction")]
        [ProducesResponseType(typeof(Transaction), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTransactionById(string id)
        {
            return Ok(await _repository.DeleteTransaction(id));
        }
    }
}
