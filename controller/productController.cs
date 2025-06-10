using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



[Tags("Products")]
[Route("api/products")]
[Produces("application/json")]
public class ProductController(IProductService productService) : ControllerBase
{
    /// <summary>
    /// Create new product.
    /// </summary>
    /// <response code="201">Returns the newly created product</response>
    [HttpPost]
    public async Task<ActionResult<Product?>> CreateProduct([FromBody] ProductDto request)
    {
        try
        {
            var product = await productService.CreateProduct(request);
            return StatusCode(201, product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    /// <summary>
    /// Return all products by admin only.
    /// </summary>
    /// <response code="200">Return all products.</response>
    [Authorize(Roles = "admin")]
    [HttpGet]
    public async Task<ActionResult<List<Product?>>> GetAllProducts()
    {
        try
        {
            var productLists = await productService.GetAllProducts();
            return Ok(productLists);
        }
        catch (ProductNotFoundException pe)
        {
            return StatusCode(404, pe);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Return product info by admin only.
    /// </summary>
    /// <response code="200">Return the product.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProductByID(Guid id)
    {
        try
        {
            var product = await productService.GetProductByID(id);
            return Ok(product);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ProductNotFoundException pe)
        {
            return StatusCode(404, pe.Message);
        }
    }

    /// <summary>
    /// Update the product by admin only.
    /// </summary>
    /// <response code="200">Update product success.</response>
    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<Product?>> UpdateProductInfo(Guid id, [FromBody] ProductDto request)
    {
        try
        {
            var product = await productService.UpdateProductInfo(id, request);
            return Ok(product);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ProductNotFoundException pe)
        {
            return StatusCode(404, pe);
        }
    }

    /// <summary>
    /// Delete the product by admin only.
    /// </summary>
    /// <response code="200">Delete the product success.</response>
    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Product>?>> DeleteProduct(Guid id)
    {
        try
        {
            var productLists = await productService.DeleteProduct(id);
            return Ok(productLists);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (ProductNotFoundException ex)
        {
            return StatusCode(404, ex.Message);
        }
    }


    /// <summary>
    /// Search products.
    /// </summary>
    /// <response code="200">Return product list.</response>
    [HttpPost("search")]
    public async Task<ActionResult<List<Product>?>> SearchProduct([FromQuery] ProductSearch request)
    {
        try
        {
            var productList = await productService.SearchProduct(request);
            return Ok(productList);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Generate summary report.
    /// </summary>
    /// <response code="200">Return summary report.</response>
    [HttpGet("report")]
    public async Task<ActionResult<SummaryReport?>> GenerateSummaryReport()
    {
        try
        {
            var report = await productService.GenerateSummaryReport();
            return Ok(report);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

}