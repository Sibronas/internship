namespace Internship.Business;

public class MeetingServiceException : Exception
{
    public MeetingServiceException()
    {
    }

    public MeetingServiceException(string message)
        : base(message)
    {
    }

    public MeetingServiceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}