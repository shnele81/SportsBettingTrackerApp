namespace SportsBettingTrackerApp.Models;

public class LoginViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginViewModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

}