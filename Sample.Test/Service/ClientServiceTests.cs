using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sample.Repo.Entities;
using Sample.Repo.Repository;
using Sample.Service;
using Sample.Service.Service;
using Sample.Shared;

namespace Sample.Test.Service
{
    [TestClass]
    public class ClientServiceTests
    {
        [TestMethod]
        public async Task Test_CreateClient()
        {
            // automapper
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            // dbclient
            var mockClient = new Client
            {
                Id = 1,
                Email = "test@email.com",
                Name = "tesft"
            };
            var mockClientRepo = new Mock<IClientRepository>();
            mockClientRepo.Setup(u => u.AddClientAsync(It.IsAny<Client>()))
                .ReturnsAsync(mockClient);

            // service
            var clientService = new ClientService(mockClientRepo.Object, mapper);

            var clientToTest = new ClientSaveDto
            {
                Id = 1,
                Email = "test@email.com",
                Name = "test"
            };
            var createdClient = await clientService.AddClientAsync(clientToTest);

            //Assert
            Assert.IsNotNull(createdClient);
            Assert.AreEqual(mockClient.Id, createdClient.Id);
            mockClientRepo.Verify(u => u.AddClientAsync(It.IsAny<Client>()), Times.Once);
        }

        [TestMethod]
        public async Task Test_Get_Client()
        {
            // automapper
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            // dbClient
            var mockClient = new Client
            {
                Id = 1,
                Email = "test@gmail.com",
                Name = "test"
            };

            var mockClientRepo = new Mock<IClientRepository>();
            mockClientRepo.Setup(u => u.GetClientAsync(It.Is<int>(u => u == 1)))
                .ReturnsAsync(mockClient);

            var clientService = new ClientService(mockClientRepo.Object, mapper);

            var client = await clientService.GetClientAsync(1);

            Assert.IsNotNull(client);
            Assert.AreEqual(mockClient.Id, client.Id);
            mockClientRepo.Verify(u => u.GetClientAsync(It.Is<int>(u => u == 1)), Times.Once);
        }

        [TestMethod]
        public async Task Test_Get_Clients()
        {
            // automapper
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            // les clients de bd
            var mockClient1 = new Client
            {
                Id = 1,
                Email = "test@gmail.com",
                Name = "test"
            };
            var mockClient2 = new Client
            {
                Id = 2,
                Email = "test2@gmail.com",
                Name = "test"
            };
            var mockClientList = new List<Client>() { mockClient1, mockClient2 };

            var mockClientRepo = new Mock<IClientRepository>();

            mockClientRepo.Setup(u => u.GetAllClientsAsync()).ReturnsAsync(mockClientList);

            var clientService = new ClientService(mockClientRepo.Object, mapper);

            var clients = await clientService.GetAllClientsAsync();

            Assert.IsNotNull(clients);
            Assert.AreEqual(2, clients.Count());

            var firstClient = clients.First();
            Assert.IsNotNull(firstClient);
            Assert.AreEqual(1, firstClient.Id);

            var secondClient = clients.Last();
            Assert.IsNotNull(secondClient);
            Assert.AreEqual(2, secondClient.Id);
        }
    }
}
