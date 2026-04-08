namespace JiraLike.Application.Mapper
{
    using AutoMapper;
    using JiraLike.Application.Dto.ProjectUser;
    using JiraLike.Application.Dto.User;
    using JiraLike.Application.Dtos.User;
    using JiraLike.Domain.Entities;
    using Microsoft.AspNetCore.Connections;
    using Microsoft.AspNetCore.Identity;

    public sealed class UserMapper : Profile
    {
        public UserMapper()
        {


            CreateMap<UpdateUserRequestDto, UserEntity>()
                // Explicit mappings
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))

                // Security: Password handled outside AutoMapper
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())

                // EF Core navigation properties (must be ignored)
                .ForMember(dest => dest.ProjectUsers, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokens, opt => opt.Ignore());



            // Entity ➜ Response Dto

            CreateMap<UserEntity, UserResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.ShortCode, opt => opt.MapFrom(src => src.ShortCode))
                .ForMember(dest => dest.UserSequence, opt => opt.MapFrom(src => src.UserSequence));

            CreateMap<ProjectUserEntity, ProjectUserResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
