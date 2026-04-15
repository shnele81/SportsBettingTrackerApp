namespace SportsBettingTrackerApp.Models;

public class UserModel
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }

    public UserModel(string username, string email, string passwordHash)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }
    private UserModel() { }

}