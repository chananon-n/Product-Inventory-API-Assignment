public class TokenResponseDto
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}

public class RefreshTokenRequestDto
{
    public Guid UID { get; set; }
    public required string RefreshToken { get; set; }
}