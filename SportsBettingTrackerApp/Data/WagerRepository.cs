using System.Data;
using SportsBettingTrackerApp.Models;

namespace SportsBettingTrackerApp.Data;

public class WagerRepository : IWagerRepository
{
    private readonly IDbConnection _connection;
    
    public WagerRepository (IDbConnection connection)
    {
        _connection = connection;
    }

    public void InsertWager(WagerModel wagerToInsert)
    {
        throw new NotImplementedException();
    }

    public void UpdateWager(WagerModel wagerToUpdate)
    {
        throw new NotImplementedException();
    }

    public void DeleteWager(int WagerId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<WagerModel> GetWagersByFilter(string? sport, string? wagerType, DateTime? date)
    {
        throw new NotImplementedException();
    }
}