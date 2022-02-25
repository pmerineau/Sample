using Sample.Repo.Entities;

namespace Sample.Repo.Repository
{
    public interface IClientRepository: IBaseRepository<Client>
    {
        Task<Client> AddClientAsync(Client client);
        Task<Client?> GetClientAsync(int id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> UpdateClientAsync(Client client);
        Task<Client> DeleteClientAsync(int id);
    }

    public sealed class ClientRepository : BaseRepository<Client>, IClientRepository // sealed aussi
    {
        
        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            return await base.AddAsync(client);
        }

        public async Task<Client?> GetClientAsync(int id)
        {
            return await base.GetAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await base.GetAllAsync();
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            return await base.UpdateAsync(client);
        }

        public async Task<Client> DeleteClientAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
    }
}
