using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        public IProductService ProductService { get; }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await ProductService.GetProductListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await ProductService.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpGet]
        [Route("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await ProductService.GetProductsByCategoryListAsync(categoryUrl);
            return Ok(result);
        }
    }
}
