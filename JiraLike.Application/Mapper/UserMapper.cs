namespace JiraLike.Application.Mapper
{
    using AutoMapper;
    using JiraLike.Application.Dto;
    using JiraLike.Domain.Entities;
    using MediatR;

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
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
                
        }
    }
}
