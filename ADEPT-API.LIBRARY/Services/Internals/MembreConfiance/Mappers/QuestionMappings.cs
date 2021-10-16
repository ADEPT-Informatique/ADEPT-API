using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Requests;
using AutoMapper;
using Sakura.AspNetCore;
using System.Linq;

namespace ADEPT_API.LIBRARY.Services.Internals.MembreConfiance.Mappers
{
    public class QuestionMappings : Profile
    {
        public QuestionMappings()
        {
            CreateMap<QuestionCreateRequestDto, Question>()
             .ForMember(dst => dst.Content, opt => opt.MapFrom(src => src.Content))
             .ForMember(dst => dst.Activated, opt => opt.MapFrom(src => src.IsActivated))
             .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Question, QuestionDto>()
                .ForMember(dst => dst.IsActivated, opt => opt.MapFrom(src => src.Activated))
                .ForMember(dst => dst.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<QuestionUpdateRequestDto, Question>()
                .ForMember(dst => dst.Activated, opt => opt.MapFrom(src => src.IsActivated))
                .ForMember(dst => dst.Content, opt => opt.MapFrom(src => src.Content))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PagedList<IQueryable<Question>, Question>, PaginatedCollectionResultDto<QuestionDto>>()
                .ForMember(dst => dst.CurrentPage, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dst => dst.PageCount, opt => opt.MapFrom(src => src.TotalPage))
                .ForMember(dst => dst.TotalCount, opt => opt.MapFrom(src => src.TotalCount))
                .ForMember(dst => dst.Result, opt => opt.MapFrom(src => src.ToList()))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
