namespace NubimetricsChallenge.Application.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Mail { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}
