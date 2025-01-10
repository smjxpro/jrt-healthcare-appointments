namespace Healthcare.Appointments.Application.Users.Dtos;

public record UserDto(Guid Id, string Email, string Name, string UserName, IList<string> Roles);