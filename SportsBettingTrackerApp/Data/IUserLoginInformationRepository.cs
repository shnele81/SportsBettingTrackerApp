using SportsBettingTrackerApp.Models;

namespace SportsBettingTrackerApp.Data;

public interface IUserLoginInformationRepository
{
    UserModel? GetUserByEmail(string email);
    void InsertUser(UserModel user);
}
