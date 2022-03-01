namespace Internship.Business.Helpers;

public static class ConsoleHelpers
{
    public static string GetString(string inputMessage, string errorMessage = null)
    {
        Console.WriteLine(inputMessage);
        var userResponse = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(userResponse)) return userResponse;

        Console.WriteLine(errorMessage ?? "Invalid value.");

        return GetString(inputMessage, errorMessage);
    }

    public static DateTime GetDateTime(string inputMessage, string errorMessage)
    {
        Console.WriteLine(inputMessage);
        var userResponse = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userResponse))
        {
            Console.WriteLine(errorMessage);
            return GetDateTime(inputMessage, errorMessage);
        }

        if (DateTime.TryParse(userResponse, out var date)) return date;

        Console.WriteLine("Invalid end date format.");
        return GetDateTime(inputMessage, errorMessage);
    }

    public static T GetEnum<T>(string inputMessage, string errorMessage) where T : struct, IConvertible
    {
        Console.WriteLine(inputMessage);
        var userResponse = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userResponse))
        {
            Console.WriteLine(errorMessage);
            return GetEnum<T>(inputMessage, errorMessage);
        }

        if (Enum.TryParse<T>(userResponse, out var result)) return result;

        Console.WriteLine(errorMessage);
        return GetEnum<T>(inputMessage, errorMessage);
    }
}