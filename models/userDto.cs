
using System.ComponentModel.DataAnnotations;

public class UserDto()
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required string Role { get; set; }
}

public class UserLoginDto()
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }
}

