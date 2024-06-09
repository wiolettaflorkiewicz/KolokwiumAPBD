using KolokwiumDF.DTOs;
using KolokwiumDF.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KolokwiumDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDto paymentDto)
        {
            try
            {
                var paymentId = await _paymentService.AddPaymentAsync(paymentDto.IdClient, paymentDto.IdSubscription, paymentDto.Amount);
                if (paymentId == null)
                {
                    return BadRequest("Payment could not be processed.");
                }
                return Ok(paymentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
