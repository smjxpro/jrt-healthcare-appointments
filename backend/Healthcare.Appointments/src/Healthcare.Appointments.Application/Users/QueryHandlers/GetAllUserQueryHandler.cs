using Healthcare.Appointments.Application.Users.Dtos;
using Healthcare.Appointments.Application.Users.Queries;
using Healthcare.Appointments.Domain.Contracts;
using MapsterMapper;
using MediatR;

namespace Healthcare.Appointments.Application.Users.QueryHandlers;

public class GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetAllUserQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetUsersAsync(request.Page, request.PageSize, request.Search, cancellationToken);

        return mapper.Map<IEnumerable<UserDto>>(users);
    }
}
