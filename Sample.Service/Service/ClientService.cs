using AutoMapper;
using Sample.Repo.Entities;
using Sample.Repo.Repository;
using Sample.Shared;

namespace Sample.Service.Service
{
    public interface IClientService
    {
        Task<ClientGetDto> GetClientAsync(int id);
        Task<IEnumerable<ClientGetDto>> GetAllClientsAsync();
        Task<ClientGetDto> UpdateClientAsync(ClientSaveDto client);
        Task<ClientGetDto> AddClientAsync(ClientSaveDto client);
        Task DeleteClientAsync(int id);
    }

    public sealed class ClientService : IClientService // la class est sealed 
    {
        private readonly IClientRepository _clientRepo;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepo, IMapper mapper)
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        public async Task<ClientGetDto> AddClientAsync(ClientSaveDto client)
        {
            var dbClient = _mapper.Map<Client>(client);
            var result = await _clientRepo.AddClientAsync(dbClient);
            return _mapper.Map<ClientGetDto>(result);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _clientRepo.DeleteClientAsync(id);
        }

        public async Task<ClientGetDto> UpdateClientAsync(ClientSaveDto client)
        {
            var dbClient = _mapper.Map<Client>(client);
            var result = await _clientRepo.UpdateClientAsync(dbClient);
            return _mapper.Map<ClientGetDto>(result);
        }

        public async Task<ClientGetDto> GetClientAsync(int id)
        {
            var result = await _clientRepo.GetClientAsync(id);
            return _mapper.Map<ClientGetDto>(result);
        }

        public async Task<IEnumerable<ClientGetDto>> GetAllClientsAsync()
        {
            var result = await _clientRepo.GetAllClientsAsync(); 
            return _mapper.Map<IEnumerable<ClientGetDto>>(result);
        }


    }
}
