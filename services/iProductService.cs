public interface IProductService
{

    Task<Product?> CreateProduct(ProductDto request);
    Task<List<Product>?> GetAllProducts();
    Task<Product?> GetProductByID(Guid productID);
    Task<Product?> UpdateProductInfo(Guid productID, ProductDto request);
    Task<List<Product>?> DeleteProduct(Guid productID);
    Task<List<Product>?> SearchProduct(ProductSearch request);
    Task<SummaryReport?> GenerateSummaryReport();


}