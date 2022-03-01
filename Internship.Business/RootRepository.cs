using Internship.Data;

namespace Internship.Business;

public interface IRootRepository
{
    Task<Root> GetRoot();
    void SaveRoot();
}

public class RootRepository : IRootRepository
{
    private static Root _database;

    private readonly IFileService _fileService;

    public RootRepository()
    {
        _fileService = new FileService();
    }

    public async Task<Root> GetRoot()
    {
        if (_database is null)
        {
            _database = await _fileService.Read();
        }

        return _database;
    }

    public void SaveRoot()
    {
        _fileService.Save(_database);
    }
}