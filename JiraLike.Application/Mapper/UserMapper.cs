namespace JiraLike.Application.Mapper
{
    using AutoMapper;
    using JiraLike.Domain.Dtos;
    using JiraLike.Domain.Entities;
    using MediatR;

    public sealed class UserMapper : Profile
    {
        public UserMapper()
        {
           
            CreateMap<AddUserRequestDto, UserEntity>()
                // Explicit mappings
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))

                // Security: Password handled outside AutoMapper
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())

                // EF Core navigation properties (must be ignored)
                .ForMember(dest => dest.ProjectUsers, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedTasks, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokens, opt => opt.Ignore());


           
            // Entity ➜ Response DTO
           
            CreateMap<UserEntity, GetUserResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))

                // API response fields
                .ForMember(dest => dest.Success, opt => opt.Ignore())
                .ForMember(dest => dest.Message, opt => opt.Ignore());
        }
    }
}
