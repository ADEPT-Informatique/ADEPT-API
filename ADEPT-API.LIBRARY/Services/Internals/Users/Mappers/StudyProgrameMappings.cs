using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services.Internals.Users.Mappers
{
    public class StudyProgrameMappings : Profile
    {
        public StudyProgrameMappings()
        {
            CreateMap<StudyProgramCreateRequestDto, StudyProgram>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<StudyProgram, StudyProgramDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForAllOtherMembers(opt => opt.Ignore());
        }

    }
    
}
