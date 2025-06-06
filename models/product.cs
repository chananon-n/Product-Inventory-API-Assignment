using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Products")]
public class Product()
{
    [Key]
    public int ID { get;  set; }

    [Required]
    public string Name { get;  set; } 

    [Required, RegularExpression(@"^[a-zA-Z0-9]{4,10}$", ErrorMessage = "SKU must be alphanumeric and 4–10 characters long")]
    public string SKU { get;  set; } 

    [Required]
    public int Quantity { get; set; } 

    [Required]
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

}