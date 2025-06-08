using System.ComponentModel.DataAnnotations;
public class ProductDto
{

    [Required]
    public required string Name { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]{4,10}$", ErrorMessage = "SKU must be alphanumeric and 4–10 characters long")]
    public required string SKU { get; set; }

    [Required]
    public required int Quantity { get; set; }

}

public class ProductSearch
{
    [Required]
    public required string Name { get; set; }

    public int? minQty { get; set; }

    public string? sort { get; set; }
}

