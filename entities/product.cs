using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Products")]
public class Product()
{
    [Key]
    public int ID { get;  set; }

    [Required]
    public required string Name { get;  set; } 

    [Required, RegularExpression(@"^[a-zA-Z0-9]{4,10}$", ErrorMessage = "SKU must be alphanumeric and 4–10 characters long")]
    public required string SKU { get;  set; } 

    [Required]
    public required int Quantity { get; set; } 

    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

}