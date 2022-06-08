using NubimetricsChallenge.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NubimetricsChallenge.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    [MaxLength(120, ErrorMessage = "El nombre debe contener 120 caracteres o menos")]
    public string FirstName { get; set; } = String.Empty;
    [Required]
    [MaxLength(120, ErrorMessage = "El Apellido debe contener 120 caracteres o menos")]
    public string LastName { get; set; } = String.Empty;
    [Required]
    [MaxLength(80)]
    public string Mail { get; set; } = String.Empty;
    [Required]
    [MaxLength(30), MinLength(8)]
    public string Password { get; set; } = String.Empty;
}
