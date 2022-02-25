using AutoMapper;
using Sample.Repo.Entities;
using Sample.Shared;

namespace Sample.Service
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<ClientSaveDto, Client>();
            CreateMap<Client, ClientGetDto>();
        }
    }
}
