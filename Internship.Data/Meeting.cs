namespace Internship.Data;

public class Meeting
{
    public string Name { get; set; }
    public string ResponsiblePerson { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public MeetingType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}