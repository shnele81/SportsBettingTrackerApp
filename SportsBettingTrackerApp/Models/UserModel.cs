namespace SportsBettingTrackerApp.Models;

public class UserModel
{
    public int ID { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public UserModel(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }


}