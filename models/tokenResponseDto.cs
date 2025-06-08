using System.ComponentModel.DataAnnotations;

public class TokenResponseDto
{
    [Required]
    public required string AccessToken { get; set; }
    [Required]
    public required string RefreshToken { get; set; }
}

public class RefreshTokenRequestDto
{
    [Required]
    public Guid UID { get; set; }
    [Required]
    public required string RefreshToken { get; set; }
}