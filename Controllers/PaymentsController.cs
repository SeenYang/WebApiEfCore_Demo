using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiEfCorePoc.Repos;

namespace WebApiEfCorePoc.Controllers
{
    [Route("[controller]s")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsRepository _repo;

        public PaymentsController(IPaymentsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetPaymentHistoryByUserId/{userId}")]
        public async Task<IActionResult> GetPaymentHistoryByUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("User id cannot be empty.");
            }

            var result = await _repo.GetPaymentHistoriesByUserId(userId);

            return Ok(result);
        }
    }
}