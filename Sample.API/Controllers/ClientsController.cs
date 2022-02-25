using Microsoft.AspNetCore.Mvc;
using Sample.Service.Service;
using Sample.Shared;

namespace Sample.API.Controllers
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

        [HttpGet("Clients")]
        public async Task<ActionResult<IEnumerable<ClientGetDto>>> GetAllClients()
        {
            var result = await _clientService.GetAllClientsAsync();
            return Ok(result);
        }

        [HttpGet("Clients/{id}")]
        public async Task<ActionResult<ClientGetDto>> GetClient(int id)
        {
            var result = await _clientService.GetClientAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPost("Client")]
        public async Task<ActionResult<ClientGetDto>> AddClient(ClientSaveDto client)
        {
            var result = await _clientService.AddClientAsync(client);
            return Ok(result);
        }

        [HttpPut("Client")]
        public async Task<ActionResult<ClientGetDto>> UpdateClient(ClientSaveDto client)
        {
            var result = await _clientService.UpdateClientAsync(client);
            return Ok(result);
        }
    }
}