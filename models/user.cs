using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Users")]
public class User(string username, string password)
{
    [Key]
    public string UID { get; set; }


    [Required]
    public string Username { get; set; } = username;

    [Required]
    public string Password { get; set; } = password;
}
