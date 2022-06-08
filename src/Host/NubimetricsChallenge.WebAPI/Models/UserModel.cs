using System.ComponentModel.DataAnnotations;
namespace NubimetricsChallenge.WebAPI.Models;

public class UserModel
{
    [Required]
    public string FirstName { get; set; } = String.Empty;
    [Required]
    public string LastName { get; set; } = String.Empty;
    [Required]
    public string Mail { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
}
