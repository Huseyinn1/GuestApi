using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace FullStack.API.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GuestDtoForUpdate, Guest>().ForMember(dest => dest.Id, opt => opt.Ignore()); ;
            CreateMap<Guest, GuestDto>();
        }
    }
}
