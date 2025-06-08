using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Products")]
public class Product()
{
    [Key]
    public Guid ID { get;  set; }

    [Required]
    public string Name { get;  set; }   = string.Empty;

    [Required]
    public string SKU { get;  set; }   = string.Empty;

    [Required]
    public int Quantity { get; set; }  = 0;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

}