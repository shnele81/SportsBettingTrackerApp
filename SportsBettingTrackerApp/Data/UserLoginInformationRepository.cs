using System.Data;
using Dapper;
using SportsBettingTrackerApp.Models;

namespace SportsBettingTrackerApp.Data;

public class UserLoginInformationRepository : IUserLoginInformationRepository
{
    private readonly IDbConnection _connection;
    
    public UserLoginInformationRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public UserModel GetUserByEmail(string email)
    {
        return _connection.QuerySingleOrDefault<UserModel>("SELECT * FROM UserLoginInformation WHERE email = @email", new { email });
    }

    public void InsertUser(UserModel user)
    {
        _connection.Execute(
                "INSERT INTO UserLoginInformation (username, email, password_hash) VALUES (@username, @email, @passwordHash)",
                new { username = user.username, email = user.email, passwordHash = user.password_hash });
    }
}