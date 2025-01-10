using Healthcare.Appointments.Application.Users.Dtos;
using MediatR;

namespace Healthcare.Appointments.Application.Users.Queries;

public record GetAllUserQuery(int Page = 1, int PageSize = 10, string? Search = null) : IRequest<IEnumerable<UserDto>>;