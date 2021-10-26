using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using AutoMapper;

namespace ADEPT_API.LIBRARY.Services.Internals.Users.Mappers
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<AuthenticateInDto, User>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Program, opt => opt.MapFrom(src => src.Program))
                .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dst => dst.StudentNumber, opt => opt.MapFrom(src => src.StudentNumber))
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
