public class SummaryReport
{
    public int TotalProductDto { get; set; }
    public int TotalStock { get; set; }

    public TopProductSummary? TopProduct { get; set; }

}

public class TopProductSummary
{
    public string? Name { get; set; }
    public int? Quantity { get; set; }

}