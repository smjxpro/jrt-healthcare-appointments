using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Application.Doctors.Queries;
using Healthcare.Appointments.Application.Doctors.QueryHandlers;
using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using MapsterMapper;
using Moq;

namespace Healthcare.Appointments.Tests.Application;

public class DoctorTests
{
    private readonly Mock<IDoctorRepository> _doctorRepository;
    private readonly Mock<IMapper> _mapper;
    public DoctorTests()
    {
        _doctorRepository = new Mock<IDoctorRepository>();
        _mapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Should_Throw_NotFoundException_When_Doctor_Not_Found()
    {
        // Arrange
        var doctorId = Guid.NewGuid();
        var handler = new GetDoctorByIdQueryHandler(_doctorRepository.Object, _mapper.Object);
        _doctorRepository.Setup(x => x.GetByIdAsync(doctorId, default)).ReturnsAsync((Doctor)null);
        var query = new GetDoctorByIdQuery(doctorId);

        // Act
        Task act() => handler.Handle(query, default);

        // Assert
        await Assert.ThrowsAsync<NotFoundException>(act);
    }
}