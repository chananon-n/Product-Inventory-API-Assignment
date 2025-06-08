
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

public class ProductService(DataContext context) : IProductService
{
    public async Task<Product?> CreateProduct(ProductDto request)
    {
        if (await context.Products.AnyAsync(p => p.Name == request.Name.ToLower()))
        {
            throw new ArgumentException("Product is already exists");
        }

        var product = new Product();

        product.ID = Guid.NewGuid();
        product.Name = request.Name.ToLower();
        product.SKU = request.SKU;
        if (request.Quantity <= 0)
        {
            throw new ArgumentException("Quantity must be more than 0");
        }
        product.Quantity = request.Quantity;
        context.Add(product);
        await context.SaveChangesAsync();

        return product;

    }

    public async Task<List<Product>?> GetAllProducts()
    {
        var productLists = await context.Products.OrderBy(p => p.Name).ToListAsync();

        if (productLists is null)
        {
            throw new ProductNotFoundException();
        }
        return productLists;
    }

    public async Task<Product?> GetProductByID(Guid productID)
    {
        var product = await context.Products.FindAsync(productID);
        if (product is null)
        {
            throw new ArgumentException("Invalid product");
        }
        return product;
    }

    public async Task<Product?> UpdateProductInfo(Guid productID, ProductDto request)
    {
        var product = await context.Products.FindAsync(productID);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }
        if (product.CreatedDate < DateTime.UtcNow.AddDays(-7))
        {
            throw new ArgumentException("The created product day is older than 7 days");

        }
        product.Name = request.Name;
        product.SKU = request.SKU;
        product.Quantity = request.Quantity;
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<List<Product>?> DeleteProduct(Guid productID)
    {
        var product = await context.Products.FindAsync(productID);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }
        context.Remove(product);
        await context.SaveChangesAsync();
        return await context.Products.ToListAsync();
    }

    public async Task<List<Product>?> SearchProduct(ProductSearch request)
    {

        IQueryable<Product> productList;

        productList = context.Products.Where(p => p.Name.ToLower().Contains(request.Name));
        if (productList is null)
        {
            throw new ProductNotFoundException();
        }

        if (request.minQty < 0)
        {
            throw new ArgumentException("minQty can't be negative numbers");
        }
        else if (request.minQty > 0)
        {
            productList = productList.Where(p => p.Quantity >= request.minQty);
        }

        if (request.sort == "asc" || request.sort is null)
        {
            productList = productList.OrderBy(p => p.Quantity);
        }
        else if (request.sort == "desc")
        {
            productList = productList.OrderByDescending(p => p.Quantity);
        }
        else
        {
            throw new ArgumentException("Invalid order");
        }
        return await productList.ToListAsync();

    }

    public async Task<SummaryReport?> GenerateSummaryReport()
    {
        await Task.Delay(2000);

        var topProduct = await context.Products.OrderByDescending(p => p.Quantity).FirstOrDefaultAsync() ?? throw new ProductNotFoundException();

        // get all products
        IQueryable<Product> allProducts = context.Products;

        int totalProducts = await allProducts.CountAsync();

        int totalStocks = await allProducts.SumAsync(p => p.Quantity);

        var topProductSummary = new TopProductSummary
        {
            Name = topProduct.Name,
            Quantity = topProduct.Quantity
        };

        return new SummaryReport
        {
            TotalProductDto = totalProducts,
            TotalStock = totalStocks,
            TopProduct = topProductSummary
        };

        









    }
}