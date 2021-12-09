using AutoMapper;
using DAL.Models;
using GameStore.ViewModels.User;

namespace GameStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationDto, User>()
                .ForMember(u => u.Email, opt => opt.MapFrom(x => x.Email));
        }
    }
}