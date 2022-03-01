using System.Text.Json;
using Internship.Data;

namespace Internship.Business;

public interface IFileService
{
    Task<Root> Read();
    Task<bool> Save(Root root);
}

public class FileService : IFileService
{
    public async Task<Root> Read()
    {
        if (!File.Exists(GlobalSettings.RootFile))
        {
            File.Create(GlobalSettings.RootFile);
            return new Root();
        }

        var file = await File.ReadAllTextAsync(GlobalSettings.RootFile);

        return JsonSerializer.Deserialize<Root>(file);
    }

    public async Task<bool> Save(Root root)
    {
        if (root is null)
            return false;

        var file = JsonSerializer.Serialize(root);

        await File.WriteAllTextAsync(GlobalSettings.RootFile, file);

        return true;
    }
}