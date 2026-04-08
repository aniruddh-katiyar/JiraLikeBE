namespace JiraLike.Application.Handler.ProjectUser
{
    using AutoMapper;
    using JiraLike.Application.Command.ProjectUser;
    using JiraLike.Application.Dto.ProjectUser;
    using JiraLike.Application.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetProjectUsersHandler : IRequestHandler<GetProjectUsersQuery, List<ProjectUserResponseDto>>
    {
        private readonly IReadDbContext _readDbContext;

        private readonly IMapper _mapper;

        public GetProjectUsersHandler(IReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }
        public async Task<List<ProjectUserResponseDto>> Handle(GetProjectUsersQuery request, CancellationToken cancellationToken)
        {
            if (request is null || request.ProjectId == Guid.Empty)
            {
                return new List<ProjectUserResponseDto>();
            }

            var projectUsers = await _readDbContext.ProjectUsers.Where(pu => pu.ProjectId == request.ProjectId).Include(x => x.User).Include(x => x.Role).ToListAsync(cancellationToken);
            var projectUsersDto = _mapper.Map<List<ProjectUserResponseDto>>(projectUsers);
            return projectUsersDto;
        }
    }
}
