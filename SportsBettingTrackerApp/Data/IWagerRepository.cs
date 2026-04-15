using SportsBettingTrackerApp.Models;

namespace SportsBettingTrackerApp.Data;

public interface IWagerRepository
{
    void InsertWager(WagerModel wagerToInsert);
    void UpdateWager(WagerModel wagerToUpdate);
    void DeleteWager(int WagerId);
    IEnumerable<WagerModel> GetWagersByFilter(string? sport, string? wagerType, DateTime? date);
    
}