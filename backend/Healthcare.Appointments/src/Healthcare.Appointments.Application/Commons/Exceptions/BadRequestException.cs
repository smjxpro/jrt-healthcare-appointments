namespace Healthcare.Appointments.Application.Commons.Exceptions;

public class BadRequestException: Exception
{
    public BadRequestException(): base("Bad Request")
    {
        
    }

    public BadRequestException(string message): base(message)
    {
        
    }
}