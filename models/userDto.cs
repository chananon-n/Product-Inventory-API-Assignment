

public class UserDto()
{

    public required string Username { get; set; }

    public required string Password  { get; set; } 

    public required string Role { get; set; }
}

public class UserLoginDto()
{
    public required string Username { get; set; }

    public required string Password  { get; set; } 
}
    
