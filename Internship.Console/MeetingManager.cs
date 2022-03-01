using System.Globalization;
using Internship.Business;
using Internship.Data;

namespace Internship;

public class MeetingManager
{
    private readonly ILoginService _loginService;
    private readonly IMeetingsService _meetingsService;

    public MeetingManager()
    {
        _loginService = new LoginService();
        _meetingsService = new MeetingsService();
    }

    public void Start()
    {
        Login();
    }

    private void Menu()
    {
        var quit = false;

        switch (DoWork())
        {
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6:
                quit = true;
                break;
        }

        if (!quit)
            Menu();
    }

    private void CreateMeeting()
    {
        Console.WriteLine("Please enter meeting details:");

        var meeting = new Meeting();

        string userResponse;

        while (true)
        {
            Console.WriteLine("Name:");
            meeting.Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(meeting.Name))
                Console.WriteLine("Invalid name format.");
            else if (_meetingsService.GetMeetingByName(meeting.Name) != null)
                Console.WriteLine("Meeting with given name already exists!");
            else
                break;
        }

        while (true)
        {
            Console.WriteLine("Responsible person:");
            meeting.ResponsiblePerson = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(meeting.ResponsiblePerson))
                Console.WriteLine("Invalid responsible person name format.");
            else
                break;
        }

        while (true)
        {
            Console.WriteLine("Description:");
            meeting.Description = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(meeting.Description))
                Console.WriteLine("Invalid description format.");
            else
                break;
        }

        while (true)
        {
            Console.WriteLine("Category (CodeMonkey / Hub / Short / TeamBuilding):");

            userResponse = Console.ReadLine();

            if (!Enum.TryParse<Category>(userResponse, out var category))
            {
                Console.WriteLine("Invalid category format.");
            }
            else
            {
                meeting.Category = category;
                break;
            }
        }

        while (true)
        {
            Console.WriteLine("Type (Live / InPerson):");

            userResponse = Console.ReadLine();

            if (!Enum.TryParse<MeetingType>(userResponse, out var meetingType))
            {
                Console.WriteLine("Invalid meeting type format.");
            }
            else
            {
                meeting.Type = meetingType;
                break;
            }
        }

        while (true)
        {
            Console.WriteLine("Start date (example format: [2022-02-22 22:22]):");

            userResponse = Console.ReadLine();

            if (DateTime.TryParse(userResponse, out var startDate))
            {
                Console.WriteLine("Invalid start date format.");
            }
            else
            {
                meeting.StartDate = startDate;
                break;
            }
        }

        while (true)
        {
            Console.WriteLine("End date (example format: [2022-02-22 22:22]):");

            userResponse = Console.ReadLine();

            if (DateTime.TryParse(userResponse, out var endDate))
            {
                Console.WriteLine("Invalid end date format.");
            }
            else
            {
                meeting.EndDate = endDate;
                break;
            }
        }

        _meetingsService.CreateMeeting(meeting);

        Console.WriteLine("Meeting created!");
    }

    private int DoWork()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Create a new meeting.");
        Console.WriteLine("2. Delete a meeting.");
        Console.WriteLine("3. Add a person to meeting.");
        Console.WriteLine("4. Remove a person from meeting.");
        Console.WriteLine("5. List all meetings.");
        Console.WriteLine("6. Quit.");

        var response = Console.ReadLine();

        if (int.TryParse(response, out var choice))
        {
            if (choice is >= 1 and <= 5) return choice;
        }

        Console.WriteLine("Invalid choice.");

        return DoWork();
    }

    private void Login()
    {
        var loggedIn = false;

        while (!loggedIn)
        {
            Console.WriteLine("What is your name?");

            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please try again...");
                continue;
            }

            _loginService.Login(name);

            loggedIn = true;
        }
    }
}