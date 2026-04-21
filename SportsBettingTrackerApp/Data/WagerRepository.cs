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
        _connection.Execute("INSERT INTO wagerTracker (WagerAmount, AmountReturned, WagerType, WagerSport, WagerDate, WagerResult, UserId) " +
                            "VALUES (@WagerAmount, @AmountReturned, @WagerType, @WagerSport, @WagerDate, @WagerResult, @UserId)", wagerToInsert);
    }
    
    public void UpdateWager(WagerModel wagerToUpdate)
    {
        _connection.Execute("UPDATE wagerTracker SET WagerAmount = @WagerAmount, AmountReturned = @AmountReturned, WagerType = @WagerType, " +
            "WagerSport = @WagerSport, WagerDate = @WagerDate, WagerResult = @WagerResult, UserId = @UserId " +
            "WHERE WagerId = @WagerId", wagerToUpdate);
    }
    
    public void DeleteWager(int WagerId)
    {
        _connection.Execute("DELETE FROM wagerTracker WHERE WagerId = @WagerId", new { WagerId });
    }

    public IEnumerable<WagerModel> GetWagersByFilter(string? sport, string? wagerType, DateTime? date)
    {
        string sql = "SELECT * FROM wagerTracker WHERE 1=1";

        if (sport != null) sql += " AND WagerSport = @sport";
        if (wagerType != null) sql += " AND WagerType = @wagerType";
        if (date != null) sql += " AND WagerDate = @date";

        return _connection.Query<WagerModel>(sql, new { sport, wagerType, date });
    }

    public WagerModel GetWagerById(int WagerId)
    {
       return _connection.QuerySingle<WagerModel>("SELECT * FROM wagerTracker WHERE WagerId = @WagerId", new {WagerId});
    }
}