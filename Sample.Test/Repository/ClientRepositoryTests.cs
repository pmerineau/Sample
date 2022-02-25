using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Repo;
using Sample.Repo.Entities;
using Sample.Repo.Repository;

namespace Sample.Test.Repository
{
    [TestClass]
    public class ClientRepositoryTests : FakeRepository
    {
        [TestMethod]
        public async Task Test_Create_Client()
        {
            var newClient = new Client
            {
                Email = "test@email.com",
                Name = "test"
            };

            using (var context = new ApplicationDbContext(CreateInMemoryDatabase("Test_DB")))
            {
                var clientRepository = new ClientRepository(context);
                var dbClient = await clientRepository.AddClientAsync(newClient);
                Assert.IsNotNull(dbClient);
                Assert.AreEqual(newClient.Email, dbClient.Email);
                Assert.AreEqual(newClient.Name, dbClient.Name);
            }
        }

        [TestMethod]
        public async Task Test_GetClient()
        {
            var newClient = new Client
            {
                Email = "test@email.com",
                Name = "test"
            };

            using (var context = new ApplicationDbContext(CreateInMemoryDatabase("Test_DB")))
            {
                //cree le client direct via le ApplicationDbContext pour qui soit dans bd
                context.Clients.Add(newClient);
                await context.SaveChangesAsync();
                // 
                var clientRepository = new ClientRepository(context);
                var clientdb = clientRepository.GetClientAsync(1);
                Assert.IsNotNull(clientdb);
            }
        }
    }
}
