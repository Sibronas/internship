using Internship.Data;

namespace Internship.Business;

public interface IMeetingsService
{
    Task CreateMeeting(Meeting meeting);
    Task RemoveMeeting(Meeting meeting);
    Task<Meeting> GetMeetingByName(string meetingName);
}

public class MeetingsService : IMeetingsService
{
    private readonly IRootRepository _repository;
    private readonly ILoginService _loginService;

    public MeetingsService()
    {
        _repository = new RootRepository();
        _loginService = new LoginService();
    }

    public async Task CreateMeeting(Meeting meeting)
    {
        if (meeting is null)
            throw new InvalidOperationException("Meeting cannot be null!");

        var root = await _repository.GetRoot();

        root.Meetings.Add(meeting);

        _repository.SaveRoot();
    }

    public async Task RemoveMeeting(Meeting meeting)
    {
        if (meeting is null)
            throw new ArgumentNullException(nameof(meeting));

        var currentUser = _loginService.GetCurrentUser();

        if (meeting.ResponsiblePerson != currentUser)
            throw new InvalidOperationException("Cannot remove this meeting. You're not the responsible person!");

        var root = await _repository.GetRoot();

        root.Meetings.Remove(meeting);
    }

    public async Task<Meeting> GetMeetingByName(string meetingName)
    {
        var root = await _repository.GetRoot();

        return root.Meetings.FirstOrDefault(x => x.Name.Equals(meetingName, StringComparison.OrdinalIgnoreCase));
    }
}