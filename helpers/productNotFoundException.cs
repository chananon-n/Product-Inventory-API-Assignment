

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message)
        : base(message)
    {
    }

    public ProductNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}