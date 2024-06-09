using KolokwiumDF.DTOs;
using KolokwiumDF.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KolokwiumDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{idClient}")]
        public async Task<IActionResult> GetClientWithSubscriptions(int idClient)
        {
            var client = await _clientService.GetClientWithSubscriptionsAsync(idClient);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
    }
}
