using JiraLike.Domain.Enums;

namespace JiraLike.Application.Mapper
{
    using AutoMapper;
    using JiraLike.Application.Dto.Issue;
    using JiraLike.Domain.Entities;

    public class IssueMapper  :Profile
    {
        public IssueMapper()
        {
            CreateMap<IssueEntity, IssueResponseDto>()
                // .ForMember(dest => dest.AssigneeName , opt => opt.MapFrom(src => src.Assignee.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
