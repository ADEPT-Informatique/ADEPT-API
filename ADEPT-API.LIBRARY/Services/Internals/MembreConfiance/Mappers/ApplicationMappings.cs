using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests;
using ADEPT_API.DATACONTRACTS.Models.MembreConfiance.Enums;
using ADEPT_API.LIBRARY.Utilities;
using AutoMapper;
using Sakura.AspNetCore;
using System.Linq;

namespace ADEPT_API.LIBRARY.Services.Internals.MembreConfiance.Mappers
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<ApplicationCreateRequestDto, Application>()
                .ForMember(dst => dst.CreatedTimestampUtc, opt => opt.MapFrom(src => EpochUtility.GetTimestampUtcSeconds()))
                .ForMember(dst => dst.ApplicationQuestions, opt => opt.MapFrom(src => src.ApplicationQuestions))
                .ForMember(dst => dst.State, opt => opt.MapFrom(src => ApplicationStates.Pending))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ApplicationUpdateRequestDto, Application>()
                .ForMember(dst => dst.ApplicationQuestions, opt => opt.MapFrom(src => src.Questions))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ApplicationUpdateStateRequestDto, Application>()
                .ForMember(dst => dst.State, opt => opt.MapFrom(src => src.State))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Application, ApplicationDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dst => dst.ApplicationQuestions, opt => opt.MapFrom(src => src.ApplicationQuestions))
                .ForMember(dst => dst.CreatedTimestampUtc, opt => opt.MapFrom(src => src.CreatedTimestampUtc))
                .ForMember(dst => dst.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dst => dst.ReviewedTimestampUtc, opt => opt.MapFrom(src => src.ReviewedTimestampUtc))
                .ForMember(dst => dst.ReviewerUser, opt => opt.MapFrom(src => src.Reviewer))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PagedList<IQueryable<Application>, Application>, PaginatedCollectionResultDto<ApplicationDto>>()
                .ForMember(dst => dst.CurrentPage, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dst => dst.PageCount, opt => opt.MapFrom(src => src.TotalPage))
                .ForMember(dst => dst.TotalCount, opt => opt.MapFrom(src => src.TotalCount))
                .ForMember(dst => dst.Result, opt => opt.MapFrom(src => src.ToList()))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ApplicationQuestion, ApplicationQuestionDto>()
                .ForMember(dst => dst.QuestionId, opt => opt.MapFrom(src => src.QuestionId))
                .ForMember(dst => dst.ApplicationId, opt => opt.MapFrom(src => src.ApplicationId))
                .ForMember(dst => dst.Answer, opt => opt.MapFrom(src => src.Answer))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ApplicationQuestionCreateRequestDto, ApplicationQuestion>()
                .ForMember(dst => dst.QuestionId, opt => opt.MapFrom(src => src.QuestionId))
                .ForMember(dst => dst.Answer, opt => opt.MapFrom(src => src.Answer))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ApplicationQuestionUpdateRequestDto, ApplicationQuestion>()
                .ForMember(dst => dst.QuestionId, opt => opt.MapFrom(src => src.QuestionId))
                .ForMember(dst => dst.ApplicationId, opt => opt.MapFrom(src => src.ApplicationId))
                .ForMember(dst => dst.Answer, opt => opt.MapFrom(src => src.Answer))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
