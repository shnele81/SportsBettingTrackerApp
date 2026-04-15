using System.Data;
using Dapper;
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
        _connection.Execute("INSERT INTO wagertracker (WagerAmount, AmountReturned, WagerType, WagerSport, WagerDate, WagerResult) " +
                            "VALUES (@WagerAmount, @AmountReturned, @WagerType, @WagerSport, @WagerDate, @WagerResult)", wagerToInsert);
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
        string sql = "SELECT * FROM Wagers WHERE 1=1";

        if (sport != null) sql += " AND WagerSport = @sport";
        if (wagerType != null) sql += " AND WagerType = @wagerType";
        if (date != null) sql += " AND WagerDate = @date";

        return _connection.Query<WagerModel>(sql, new { sport, wagerType, date });
    }
}