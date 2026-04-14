namespace SportsBettingTrackerApp.Models;

public class UserModel
{
    public int user_id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password_hash { get; set; }

    public UserModel(string username, string email, string passwordHash)
    {
        this.username = username;
        this.email = email;
        this.password_hash = passwordHash;
    }

    private UserModel() { }
}
