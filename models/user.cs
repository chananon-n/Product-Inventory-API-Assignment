using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Users")]
public class User()
{
    [Key]
    public string UID { get; set; }


    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; } 
}
