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
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("Clients/{id}")]
        public async Task<ActionResult<ClientGetDto>> GetClient(int id)
        {
            var client = await _clientService.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost("Client")]
        public async Task<ActionResult<ClientGetDto>> AddClient(ClientSaveDto client)
        {
            var newClient = await _clientService.AddClientAsync(client);
            return Ok(newClient);
        }

        [HttpPut("Client")]
        public async Task<ActionResult<ClientGetDto>> UpdateClient(ClientSaveDto client)
        {
            return await _clientService.UpdateClientAsync(client);
        }
    }
}