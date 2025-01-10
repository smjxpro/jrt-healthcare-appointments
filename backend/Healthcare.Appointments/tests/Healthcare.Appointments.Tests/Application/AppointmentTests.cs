using Healthcare.Appointments.Application.Appointments.CommandHandlers;
using Healthcare.Appointments.Application.Appointments.Commands;
using Healthcare.Appointments.Application.Appointments.Dtos;
using Healthcare.Appointments.Application.Commons.Exceptions;
using Healthcare.Appointments.Domain.Contracts;
using Healthcare.Appointments.Domain.Entities;
using MapsterMapper;
using Moq;

namespace Healthcare.Appointments.Tests.Application;

public class AppointmentTests
{
    private readonly Mock<IAppointmentRepository> _appointmentRepository;
    private readonly Mock<IDoctorRepository> _doctorRepository;
    private readonly Mock<IMapper> _mapper;
    public AppointmentTests()
    {
        _appointmentRepository = new Mock<IAppointmentRepository>();
        _doctorRepository = new Mock<IDoctorRepository>();
        _mapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Should_Throw_BadRequestException_When_Doctor_Not_Found()
    {
        // Arrange
        var dto = new BookAppointmentDto
        {
            PatientName = "John Doe",
            PatientContactInformation = "123456789",
            DoctorId = Guid.NewGuid(),
            DateTime = DateTimeOffset.Now.AddHours(3)
        };

        var command = new BookAppointmentCommand(Guid.NewGuid(), dto);
        var handler = new BookAppointmentCommandHandler(_appointmentRepository.Object,_doctorRepository.Object, _mapper.Object);

        // Act
        Task act() => handler.Handle(command, default);
        // Assert
        await Assert.ThrowsAsync<BadRequestException>(act);
    }

    [Fact]
    public async Task Should_Throw_BadRequestException_When_Booking_Within_One_Hour_From_Current_Time()
    {
        // Arrange
        var dto = new BookAppointmentDto
        {
            PatientName = "John Doe",
            PatientContactInformation = "123456789",
            DoctorId = Guid.NewGuid(),
            DateTime = DateTimeOffset.Now.AddHours(-1)
        };

        var command = new BookAppointmentCommand(Guid.NewGuid(), dto);
        var handler = new BookAppointmentCommandHandler(_appointmentRepository.Object,_doctorRepository.Object, _mapper.Object);

        // Act
        Task act() => handler.Handle(command, default);
        // Assert
        await Assert.ThrowsAsync<BadRequestException>(act);
    }

    [Fact]
    public async Task Should_Throw_BadRequestException_When_Booking_On_Already_Booked_Slot()
    {
        // Arrange
        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            PatientName = "John Doe",
            PatientContactInformation = "123456789",
            DoctorId = Guid.NewGuid(),
            DateTime = DateTimeOffset.Now.AddHours(3)
        };

        _appointmentRepository.Setup(x => x.GetByDoctorIdAndDateTimeAsync(It.IsAny<Guid>(), It.IsAny<DateTimeOffset>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(appointment);

        var dto = new BookAppointmentDto
        {
            PatientName = "John Doe",
            PatientContactInformation = "123456789",
            DoctorId = Guid.NewGuid(),
            DateTime = DateTimeOffset.Now.AddHours(3)
        };

        var command = new BookAppointmentCommand(Guid.NewGuid(), dto);
        var handler = new BookAppointmentCommandHandler(_appointmentRepository.Object,_doctorRepository.Object, _mapper.Object);

        // Act
        Task act() => handler.Handle(command, default);
        // Assert
        await Assert.ThrowsAsync<BadRequestException>(act);
    }
}