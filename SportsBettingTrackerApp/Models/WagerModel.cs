namespace SportsBettingTrackerApp.Models;

public class WagerModel
 {
     public int WagerId { get; set; }
     public int UserId { get; set; }
     public string WagerSport { get; set; }
     public DateTime WagerDate { get; set; }
     public string WagerType { get; set; }
     public double WagerAmount { get; set; }
     public string WagerResult { get; set; }
     public double AmountReturned { get; set; }
 }