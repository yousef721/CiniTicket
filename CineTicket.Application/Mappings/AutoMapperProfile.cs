using AutoMapper;
using CineTicket.Application.ViewModels.IdentityViewModels;
using CineTicket.Core.Entities;

namespace CineTicket.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region IdentityMap
            CreateMap<RegisterVM, ApplicationUser>()
            .ReverseMap();

            CreateMap<LoginVM, ApplicationUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Account))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Account))
            .ReverseMap();
        #endregion

    }
}
