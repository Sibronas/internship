namespace Internship.Data;

public class MeetingsSearchModel
{
    public string Description { get; set; }
    public string ResponsiblePerson { get; set; }
    public Category? Category { get; set; }
    public MeetingType? MeetingType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? NoOfAttendees { get; set; }
}