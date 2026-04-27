using System.ComponentModel.DataAnnotations;

namespace SportsBettingTrackerApp.Models;

public class WagerModel
 {
     public int WagerId { get; set; }
     public int UserId { get; set; }
     [Display (Name = "Sport")]
     public string? WagerSport { get; set; }
     
     [Display (Name = "Date of Bet")]
     public DateTime WagerDate { get; set; }
     
     [Display (Name = "Type of Bet")]
     public string? WagerType { get; set; }
     
     [Display (Name = "Amount of Bet")]
     public double WagerAmount { get; set; }
     
     [Display (Name = "Win or Loss?")]
     public string? WagerResult { get; set; }
     
     [Display (Name = "Amount of Money Returned")]
     public double AmountReturned { get; set; }
 }